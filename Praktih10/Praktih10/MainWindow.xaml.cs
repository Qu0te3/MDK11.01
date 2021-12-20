using System;
using System.Collections;
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

namespace Praktih10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList numbers = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void createArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainListBox.ItemsSource = null;
                int count = Int32.Parse(inputCount.Text);
                Random random = new();
                for (int i = 0; i < count; i++)
                {
                    numbers.Add(random.Next(-100, 101));
                }
                mainListBox.ItemsSource = numbers;
            }
            catch
            {
                MessageBox.Show("Введите количество элементов", "Ошибка");
            }

        }

        private void inputCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    e.Handled = true;
            }
            else e.Handled = false;
        }

        private void inputCount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void getNegPosCount_Click(object sender, RoutedEventArgs e)
        {
            if (numbers.Count != 0)
            {
                NegPosInArray negPosInArray = new();
                (int posResult, int negResult) = negPosInArray.GetNegPosCount(numbers);
                resultOutput.Text = ($"В данном наборе {posResult} положительных и {negResult} отрицательных значений");
            }
            else MessageBox.Show("Сначала создайте массив", "Ошибка");
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №10\n" +
                "Морарь Влад ИСП-34\n" +
                "Дан массив в диапазоне [-100;100] найти количество положительных и отрицательных.", "О программе", MessageBoxButton.OK);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
