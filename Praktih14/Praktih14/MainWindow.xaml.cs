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
using System.IO;
using Microsoft.Win32;
using LibMatrix;

namespace Praktih14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public static class MatrixSizeContainer
    {
        public static int RowCount;
        public static int ColumnCount;
    }

    public partial class MainWindow : Window
    {
        private BasicMatrixActs matrixActs = new();
        private OddColumn oddColumn = new();
        private int[,] _matrix;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                    e.Handled = true;
            }
            else e.Handled = false;
        }

        private void input_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
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
            inputRowCount.Text = Convert.ToString(_matrix.GetLength(0));
            inputColumnCount.Text = Convert.ToString(_matrix.GetLength(1));
            mainDataGrid.ItemsSource = _matrix.ToDataTable().DefaultView;
        }

        private void save_Click(object sender, RoutedEventArgs e)
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
            inputRowCount.Clear();
            inputColumnCount.Clear();
            matrixActs.ClearMatrix();
            mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №14\n" +
                "Морарь Владислав ИСП-34\n" +
                "Дана целочисленная матрица размера M * N. Найти номер первого из ее столбцов, содержащих только нечетные числа.Если таких столбцов нет, то вывести 0.", "О программе", MessageBoxButton.OK);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void createMatrix_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowCount = Int32.Parse(inputRowCount.Text);
                int columnCount = Int32.Parse(inputColumnCount.Text);
                MatrixSizeContainer.RowCount = rowCount;
                MatrixSizeContainer.ColumnCount = columnCount;
                _matrix = matrixActs.Create(rowCount, columnCount);
                mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
                matrixInfo.Content = $"Матрица {_matrix.GetLength(0)} x {_matrix.GetLength(1)}";
            }
            catch (Exception)
            {
                MessageBox.Show("Введите данные", "Ошибка");
            }
        }

        private void fillMatrix_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rowCount = Int32.Parse(inputRowCount.Text);
                int columnCount = Int32.Parse(inputColumnCount.Text);
                MatrixSizeContainer.RowCount = rowCount;
                MatrixSizeContainer.ColumnCount = columnCount;
                _matrix = matrixActs.Generate(rowCount, columnCount);
                mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
                matrixInfo.Content = $"Матрица {_matrix.GetLength(0)} x {_matrix.GetLength(1)}";
            }
            catch
            {
                MessageBox.Show("Введите данные", "Ошибка");
            }

        }

        private void getOddColumn_Click(object sender, RoutedEventArgs e)
        {
            if (_matrix != null)
            {
                int rowCount = Int32.Parse(inputRowCount.Text);
                int columnCount = Int32.Parse(inputColumnCount.Text);
                MessageBox.Show($"{oddColumn.GetColumn(_matrix)}");
            }
            else MessageBox.Show("Сгенерируйте таблицу", "Ошибка");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Authorization auth = new();
            auth.Owner = this;
            auth.ShowDialog();
        }

        private void options_Click(object sender, RoutedEventArgs e)
        {
            Options options = new();
            options.Owner = this;
            options.ShowDialog();
            inputRowCount.Text = MatrixSizeContainer.RowCount.ToString();
            inputColumnCount.Text = MatrixSizeContainer.ColumnCount.ToString();
            int rowCount = Int32.Parse(inputRowCount.Text);
            int columnCount = Int32.Parse(inputColumnCount.Text);
            _matrix = matrixActs.Generate(rowCount, columnCount);
            mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
            matrixInfo.Content = $"Матрица {_matrix.GetLength(0)} x {_matrix.GetLength(1)}";
        }

        private void inputRowCount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
