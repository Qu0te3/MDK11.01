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
using Lib_5;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int k = Int32.Parse(InputK.Text);
                Calc GetSum = new Calc();
                GetSum.GetSum115(k, out string res);
                CalcOutput.Text = res;
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректное число", "Ошибка");
            }

        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Прктическая работа №1\n" +
                "Морарь Владислав ИСП - 34\n" +
                "Вариант 5\n" +
                "Вычислить сумму целых случайных чисел, распределенных в диапазоне от - 7 до 3, " +
                "пока эта сумма не превышает некоторого числа K.Вывести на экран " +
                "сгенерированные числа, значение суммы, и количество сгенерированных чисел", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputK.Clear();
            CalcOutput.Clear();
        }
    }
}
