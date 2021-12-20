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

namespace chel_pr2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] _array;
        SimpleArray ArrayAct = new SimpleArray();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateTab_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int length = Int32.Parse(InputN.Text);
                _array = ArrayAct.GenerateRandom(length);
                MainDataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
            }
            catch
            {
                MessageBox.Show("Введите длину(положительное целое число)", "Ошибка");
            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            if (_array != null)
                ResOutput.Text = Convert.ToString(ArrayAct.Calc(_array));
            else MessageBox.Show("Сгенерируйте таблицу", "Ошибка");
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №2\n" +
                "Морарь Владислав ИСП - 34\n" +
                "Ввести n целых чисел. Найти произведение чисел < 3. Результат вывести на экран.");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputN.Clear();
            ResOutput.Clear();
            ArrayAct.Initialize(0, 0);
            MainDataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _array = ArrayAct.Open();
                MainDataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
            }
            catch (ArgumentNullException)
            {

                MessageBox.Show("");
            }

        }

        private void FileSave_Click(object sender, RoutedEventArgs e)
        {
            ArrayAct.Save();
        }
    }
}
