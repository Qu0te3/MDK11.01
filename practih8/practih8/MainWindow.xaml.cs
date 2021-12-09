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

namespace practih8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {
            GeometricProgression geometricProgression = new();
            GeometricProgression secondaryProgression;
            GeometricProgression clonedProgression;

            public MainWindow()
            {
                InitializeComponent();
            }

            private void start_Click(object sender, RoutedEventArgs e)
            {
                if (inputMainCount.Text != string.Empty && inputMainStartValue.Text != string.Empty)
                {
                    int count = Int32.Parse(inputMainCount.Text);
                    int startValue = Int32.Parse(inputMainStartValue.Text);

                    geometricProgression.SetStart(startValue);
                    mainListBox.Items.Add(geometricProgression.CurrentValue);
                    for (int i = 0; i < count; i++)
                    {
                        mainListBox.Items.Add(geometricProgression.GetNext());
                    }
                }
                else MessageBox.Show("Введите значения", "Ошибка");
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

            private void about_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Практическая работа №8\n" +
                    "Морарь Владислав ИСП-34\n" +
                    "Создать интерфейс – серия чисел. Создать класс – геометрическая прогрессия. Класс должен включать конструктор.Сравнение производить по шагу " +
                    "прогрессии.", "О программе", MessageBoxButton.OK);
            }

            private void exit_Click(object sender, RoutedEventArgs e)
            {
                Close();
            }

            private void compare_Click(object sender, RoutedEventArgs e)
            {
                if (mainListBox.Items.Count != 0 && secondaryListBox.Items.Count != 0)
                {
                    int compareResult = geometricProgression.CompareTo(secondaryProgression);
                    if (compareResult == 0)
                    {
                        MessageBox.Show("Шаги прогрессии равны", "Сравнение");
                    }
                    else MessageBox.Show("Шаги прогрессии не равны", "Сравнение");
                }
                else MessageBox.Show("Нечего сравнивать", "Ошибка");
            }

            private void startSecondary_Click(object sender, RoutedEventArgs e)
            {
                if (inputSecondaryCount.Text != string.Empty && inputSecondaryStartValue.Text != string.Empty)
                {
                    secondaryProgression = new(Int32.Parse(inputSecondaryStartValue.Text));
                    int secondaryCount = Int32.Parse(inputSecondaryCount.Text);
                    secondaryListBox.Items.Add(secondaryProgression.CurrentValue);
                    for (int i = 0; i < secondaryCount; i++)
                    {
                        secondaryListBox.Items.Add(secondaryProgression.GetNext());
                    }
                }
                else MessageBox.Show("Введите значения", "Ошибка");
            }

            private void clone_Click(object sender, RoutedEventArgs e)
            {
                if (mainListBox.Items.Count != 0)
                {
                    secondaryListBox.Items.Clear();
                    clonedProgression = (GeometricProgression)geometricProgression.Clone();
                    inputSecondaryCount.Text = inputMainCount.Text;
                    inputSecondaryStartValue.Text = clonedProgression.StartValue.ToString();
                    MessageBox.Show("Нажмите на 'Запуск' справа, чтобы склоинровать");
                }
                else MessageBox.Show("Нечего клонировать", "Ошибка");
            }

            private void clear_Click(object sender, RoutedEventArgs e)
            {
                inputMainCount.Clear();
                inputMainStartValue.Clear();
                inputSecondaryCount.Clear();
                inputSecondaryStartValue.Clear();
                mainListBox.Items.Clear();
                secondaryListBox.Items.Clear();
            }
        }
    }
