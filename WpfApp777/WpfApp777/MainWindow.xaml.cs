using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp777
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle triangle = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculatePerimeter_Click(object sender, RoutedEventArgs e)
        {
            if (isThreeSides.IsChecked.Value == true)
            {
                try
                {
                    int sideA = Int32.Parse(inputSideA.Text);
                    int sideB = Int32.Parse(inputSideB.Text);
                    int sideC = Int32.Parse(inputSideC.Text);
                    triangle.SetParams(sideA, sideB, sideC);
                    perimeterOutput.Text = triangle.GetPerimeter().ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите длины сторон", "Ошибка");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                }
            }
            else if (isOneSide.IsChecked.Value == true)
            {
                try
                {
                    int newSide = Int32.Parse(inputSide.Text);
                    triangle.Equilateral(newSide);
                    perimeterOutput.Text = triangle.GetPerimeter().ToString();
                }
                catch (FormatException)
                {

                    MessageBox.Show("Введите длины сторон", "Ошибка");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                }
            }
            else MessageBox.Show("Выберите способ ввода", "Ошибка");
        }

        private void isThreeSides_Click(object sender, RoutedEventArgs e)
        {
            if (isThreeSides.IsChecked.Value == true)
            {
                inputSideA.IsEnabled = true;
                inputSideB.IsEnabled = true;
                inputSideC.IsEnabled = true;

            }
            else
            {
                inputSideA.IsEnabled = false;
                inputSideB.IsEnabled = false;
                inputSideC.IsEnabled = false;
            }
        }

        private void doubleSizes_Click(object sender, RoutedEventArgs e)
        {
            if (isThreeSides.IsChecked.Value == true)
            {
                try
                {
                    triangle.DoubleValues();
                    inputSideA.Text = triangle.SideA.ToString();
                    inputSideB.Text = triangle.SideB.ToString();
                    inputSideC.Text = triangle.SideC.ToString();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Укажите длины сторон или рассчитайте периметр, чтобы продолжить", "Ошибка");
                }
            }
            else if (isOneSide.IsChecked.Value == true)
            {
                try
                {
                    triangle.DoubleValues();
                    inputSide.Text = triangle.SideA.ToString();
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Укажите длины сторон или рассчитайте периметр, чтобы продолжить", "Ошибка");
                }
            }
            else MessageBox.Show("Выберите способ ввода", "Ошибка");
        }

        private void isOneSide_Click(object sender, RoutedEventArgs e)
        {
            if (isOneSide.IsChecked.Value == true)
                inputSide.IsEnabled = true;
            else inputSide.IsEnabled = false;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Морарь Владислав ИСП-34\n" +
                "Практическая работа №7\n" +
                "Использовать класс Triangle (треугольник) с полями-сторонами. Создать  производный класс Equilateral(равносторонний), имеющий поле площади. " +
                "Определить метод вычисления площади.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information); ;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            inputSide.Clear();
            inputSideA.Clear();
            inputSideB.Clear();
            inputSideC.Clear();
            perimeterOutput.Clear();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void checkExistence_Click(object sender, RoutedEventArgs e)
        {


            if (isThreeSides.IsChecked.Value == true)
            {
                try
                {
                    int sideA = Int32.Parse(inputSideA.Text);
                    int sideB = Int32.Parse(inputSideB.Text);
                    int sideC = Int32.Parse(inputSideC.Text);
                    triangle.SetParams(sideA, sideB, sideC);
                    if (triangle)
                        MessageBox.Show("Треугольник с такими сторонами может существовать");
                }
                catch
                {
                    MessageBox.Show("Треугольник с такими сторонами не может существовать");
                }
            }
            else if (isOneSide.IsChecked.Value == true)
            {
                try
                {
                    int newSide = Int32.Parse(inputSide.Text);
                    triangle.Equilateral(newSide);
                    if (triangle)
                        MessageBox.Show("Треугольник с такими сторонами может сущестоввать");
                }
                catch
                {
                    MessageBox.Show("Треугольник с такими сторонами существовать не может");
                }
            }
            else MessageBox.Show("Выберите способ ввода", "Ошибка");
        }

        private void increaseSizesBy1_Click(object sender, RoutedEventArgs e)
        {
            if (isThreeSides.IsChecked.Value == true)
            {
                try
                {
                    int sideA = Int32.Parse(inputSideA.Text);
                    int sideB = Int32.Parse(inputSideB.Text);
                    int sideC = Int32.Parse(inputSideC.Text);
                    triangle.SetParams(sideA, sideB, sideC);
                    triangle++;
                    inputSideA.Text = triangle.SideA.ToString();
                    inputSideB.Text = triangle.SideB.ToString();
                    inputSideC.Text = triangle.SideC.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите длины сторон", "Ошибка");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                }
            }
            else if (isOneSide.IsChecked.Value == true)
            {
                try
                {
                    int newSide = Int32.Parse(inputSide.Text);
                    triangle.Equilateral(newSide);
                    triangle++;
                    inputSide.Text = triangle.SideA.ToString();
                }
                catch (FormatException)
                {

                    MessageBox.Show("Введите длины сторон", "Ошибка");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                }
            }
            else MessageBox.Show("Выберите способ ввода", "Ошибка");
        }

        private void reduceSizesBy1_Click(object sender, RoutedEventArgs e)
        {
            if (isThreeSides.IsChecked.Value == true)
            {
                try
                {
                    int sideA = Int32.Parse(inputSideA.Text);
                    int sideB = Int32.Parse(inputSideB.Text);
                    int sideC = Int32.Parse(inputSideC.Text);
                    triangle.SetParams(sideA, sideB, sideC);
                    triangle--;
                    inputSideA.Text = triangle.SideA.ToString();
                    inputSideB.Text = triangle.SideB.ToString();
                    inputSideC.Text = triangle.SideC.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите длины сторон", "Ошибка");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                }
            }
            else if (isOneSide.IsChecked.Value == true)
            {
                try
                {
                    int newSide = Int32.Parse(inputSide.Text);
                    triangle.Equilateral(newSide);
                    triangle--;
                    inputSide.Text = triangle.SideA.ToString();
                }
                catch (FormatException)
                {

                    MessageBox.Show("Введите длины сторон", "Ошибка");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                }
            }
            else MessageBox.Show("Выберите способ ввода", "Ошибка");
        }

        private void calculateArea_Click(object sender, RoutedEventArgs e)
        {
            if (perimeterOutput.Text == string.Empty)
            {
                MessageBoxResult perimeterEmptyResult = MessageBox.Show("Сначало нужно рассчитать периметр. Сделать это сейчас?", "Ошибка", MessageBoxButton.YesNo);
                switch (perimeterEmptyResult)
                {
                    case MessageBoxResult.Yes:
                        if (isThreeSides.IsChecked.Value == true)
                        {
                            try
                            {
                                int sideA = Int32.Parse(inputSideA.Text);
                                int sideB = Int32.Parse(inputSideB.Text);
                                int sideC = Int32.Parse(inputSideC.Text);
                                triangle.SetParams(sideA, sideB, sideC);
                                perimeterOutput.Text = triangle.GetPerimeter().ToString();
                                areaOutput.Text = triangle.GetArea().ToString();
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Введите длины сторон", "Ошибка");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                            }
                        }
                        else if (isOneSide.IsChecked.Value == true)
                        {
                            try
                            {
                                int newSide = Int32.Parse(inputSide.Text);
                                triangle.Equilateral(newSide);
                                perimeterOutput.Text = triangle.GetPerimeter().ToString();
                                areaOutput.Text = triangle.GetArea().ToString();
                            }
                            catch (FormatException)
                            {

                                MessageBox.Show("Введите длины сторон", "Ошибка");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                MessageBox.Show("Длина стороны не может быть отрицательной или равной 0", "Ошибка");
                            }
                        }
                        else MessageBox.Show("Выберите способ ввода", "Ошибка");
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else areaOutput.Text = triangle.GetArea().ToString();
        }

        private void areaOutput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
