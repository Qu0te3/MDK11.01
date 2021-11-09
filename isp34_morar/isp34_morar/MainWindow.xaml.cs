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

namespace isp34_morar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Triangle triangle = new Triangle();
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
                    triangle.SetParams(newSide);
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

        private void increaseBy2_Click(object sender, RoutedEventArgs e)
        {
            if (isThreeSides.IsChecked.Value == true)
            {
                try
                {
                    triangle.IncreaseByTwo();
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
                    triangle.IncreaseByTwo();
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
            MessageBox.Show("Морарь Влад ИСП - 34\n" +
                "Практическая работа №5\n" +
                "Создать класс Triangle (треугольник) с полями-сторонами. Создать необходимые методы и свойства.Определить метод вычисления периметра. Создать " +
                "перегруженные методы SetParams, для установки параметров объекта, в том числе увеличения размеров треугольника в 2 раза.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information); ;
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
    }
}
