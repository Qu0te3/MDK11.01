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
using LibMatrix;
using Lib_5;
using Microsoft.Win32;

namespace praktih3v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Acts matrixActs = new();
        CalculateModules averageUneven = new();
        private int[,] _matrix;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void fileSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".txt"
            };
            if (mainDataGrid.ItemsSource != null)
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    matrixActs.Save(saveFileDialog.FileName);
                }
            }
            else MessageBox.Show("Нечего сохранять", "Ошибка");
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            inputN.Clear();
            inputM.Clear();
            resOutput.Clear();
            matrixActs.ClearMatrix();
            mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
        }

        private void generateMatrix_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int n = Int32.Parse(inputN.Text);
                int m = Int32.Parse(inputM.Text);
                _matrix = matrixActs.Generate(n, m);
                mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
            }
            catch
            {
                MessageBox.Show("Введите правильные числа(положительное целое число)", "Ошибка");
            }
        }

        private void fileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".txt"
            };

            if (openFileDialog.ShowDialog() == false)
            {
                return;
            }

            _matrix = matrixActs.Open(openFileDialog.FileName);
            inputN.Text = Convert.ToString(_matrix.GetLength(0));
            inputM.Text = Convert.ToString(_matrix.GetLength(1));
            mainDataGrid.ItemsSource = _matrix.ToDataTable().DefaultView;
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (_matrix != null)
            {
                resOutput.Text = Convert.ToString(string.Join(" | ", averageUneven.AverageUneven(_matrix)));
            }
            else MessageBox.Show("Сначала сгенерируйте таблицу", "Ошибка");
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №3 \n" +
                "Морарь Владислав ИСП-34\n" +
                "Дана матрица размера M × N. Для каждой строки матрицы с нечетным номером (1, 3, …) " +
                "найти среднее арифметическое ее элементов. Условный оператор не использовать.", "О программе", MessageBoxButton.OK);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
