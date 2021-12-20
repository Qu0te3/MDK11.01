using System;
using System.Windows;
using System.Windows.Input;
using LibMatrix;
using Microsoft.Win32;

namespace Praktih13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BasicMatrixActs matrixActs = new();
        private OddColumn oddColumn = new();
        private int[,] _matrix;

        public MainWindow()
        {
            InitializeComponent();
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
            MessageBox.Show("Практическая работа №13\n" +
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
                _matrix = matrixActs.Generate(rowCount, columnCount);
                mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
            }
            catch
            {
                MessageBox.Show("Введите данные", "Ошибка");
            }
            matrixInfo.Content = $"Матрица {_matrix.GetLength(0)} x {_matrix.GetLength(1)}";
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


    }
}
