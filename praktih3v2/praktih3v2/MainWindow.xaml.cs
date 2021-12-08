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
using WpfLibrary1;
using WpfLibrary2;

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
            if (mainDataGrid.ItemsSource != null)
                matrixActs.Save();
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
            bool isNEmpty = Int32.TryParse(inputN.Text, out int n);
            bool isMEmpty = Int32.TryParse(inputM.Text, out int m);
            if (isNEmpty && isMEmpty && n > 0 && m > 0)
            {
                _matrix = matrixActs.Generate(n, m);
                mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
            }
            else MessageBox.Show("Введите правильные числа(положительное целое число)", "Ошибка");
        }

        private void fileOpen_Click(object sender, RoutedEventArgs e)
        {
            _matrix = matrixActs.Open();
            inputN.Text = Convert.ToString(_matrix.GetLength(0));
            inputM.Text = Convert.ToString(_matrix.GetLength(1));
            mainDataGrid.ItemsSource = VisualMatrix.ToDataTable(_matrix).DefaultView;
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            if (_matrix != null)
            {
                resOutput.Text = Convert.ToString(string.Join(" | ", averageUneven.AverageUneven(_matrix)));
            }
            else MessageBox.Show("Сначала сгенерируйте таблицу", "Ошибка");
        }
    }
}
