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

namespace practih_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //        Заполнить таблицу со списком сотрудников на 7 человек с полями: ФИО, пол,
        //должность, стаж работы, оклад. Вывести результат на экран.Вывести средний
        //оклад.
        Employees employee1;
        Employees employee2;
        Employees employee3;
        Employees employee4;
        Employees employee5;
        Employees employee6;
        Employees employee7;

        Employees[] employeesArray;

        public MainWindow()
        {
            InitializeComponent();
        }

        struct Employees
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            public string Gender { get; set; }
            public string Position { get; set; }
            public int WorkExperience { get; set; }
            public int Salary { get; set; }

            public Employees(string surname, string name, string patronymic, string gender, string position, int workExperience, int salary)
            {
                Name = name;
                Surname = surname;
                Patronymic = patronymic;
                Gender = gender;
                Position = position;
                WorkExperience = workExperience;
                Salary = salary;
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employees newEmployee;
                string newName = inputName.Text;
                string newSurname = inputSurname.Text;
                string newPatronymic = inputPatronymic.Text;
                string newGender = inputGender.Text;
                string newPosition = inputPosition.Text;
                int newWorkExp = Convert.ToInt32(inputWorkExp.Text);
                int newSalary = Convert.ToInt32(inputSalary.Text);
                newEmployee = new Employees(newName, newSurname, newPatronymic, newGender, newPosition, newWorkExp, newSalary);
                mainListBox.Items.Add($"{newEmployee.Surname} {newEmployee.Name} {newEmployee.Patronymic}, Пол - {newEmployee.Gender}, Должность - {newEmployee.Position}, Стаж - {newEmployee.WorkExperience} лет, Оклад - {newEmployee.Salary} руб");
            }
            catch
            {

                MessageBox.Show("Проверьте введенные значения", "Ошибка");
            }
        }

        private void employees_Click(object sender, RoutedEventArgs e)
        {
            employee1 = new Employees("Рыбакова", "Евгения", "Германовна", "Ж", "Бухгалтер", 12, 54000);
            employee2 = new Employees("Колесникова", "Свтелана", "Михайловна", "Ж", "Кассир", 5, 17800);
            employee3 = new Employees("Маслов", "Алексей", "Сергеевич", "М", "Кассир", 8, 20000);
            employee4 = new Employees("Снегирев", "Никита", "Алексеевич", "М", "Охранник склада", 15, 21300);
            employee5 = new Employees("Ананьева", "Ксения", "Романовна", "Ж", "Физик", 25, 65000);
            employee6 = new Employees("Толкачев", "Глеб", "Васильевич", "М", "Инструктор по видам спорта", 30, 43000);
            employee7 = new Employees("Попов", "Михаил", "Константинович", "М", "Генеральный директор", 30, 85000);
            mainListBox.Items.Add($"{employee1.Surname} {employee1.Name} {employee1.Patronymic}, Пол - {employee1.Gender}, Должность - {employee1.Position}, Стаж - {employee1.WorkExperience} лет, Оклад - {employee1.Salary} руб");
            mainListBox.Items.Add($"{employee2.Surname} {employee2.Name} {employee2.Patronymic}, Пол - {employee2.Gender}, Должность - {employee2.Position}, Стаж - {employee2.WorkExperience} лет, Оклад - {employee2.Salary} руб");
            mainListBox.Items.Add($"{employee3.Surname} {employee3.Name} {employee3.Patronymic}, Пол - {employee3.Gender}, Должность - {employee3.Position}, Стаж - {employee3.WorkExperience} лет, Оклад - {employee3.Salary} руб");
            mainListBox.Items.Add($"{employee4.Surname} {employee4.Name} {employee4.Patronymic}, Пол - {employee4.Gender}, Должность - {employee4.Position}, Стаж - {employee4.WorkExperience} лет, Оклад - {employee4.Salary} руб");
            mainListBox.Items.Add($"{employee5.Surname} {employee5.Name} {employee5.Patronymic}, Пол - {employee5.Gender}, Должность - {employee5.Position}, Стаж - {employee5.WorkExperience} лет, Оклад - {employee5.Salary} руб");
            mainListBox.Items.Add($"{employee6.Surname} {employee6.Name} {employee7.Patronymic}, Пол - {employee6.Gender}, Должность - {employee6.Position}, Стаж - {employee6.WorkExperience} лет, Оклад - {employee6.Salary} руб");
            mainListBox.Items.Add($"{employee7.Surname} {employee7.Name} {employee7.Patronymic}, Пол - {employee7.Gender}, Должность - {employee7.Position}, Стаж - {employee7.WorkExperience} лет, Оклад - {employee7.Salary} руб");
        }

        private void averageSalary_Click(object sender, RoutedEventArgs e)
        {
            employeesArray = new Employees[] { employee1, employee2, employee3, employee4, employee5, employee6, employee7 };
            float averageSalary;
            int counter = 0, sum = 0;
            for (int i = 0; i < employeesArray.Length; i++)
            {
                counter++;
                sum += employeesArray[i].Salary;
            }
            averageSalary = (float)sum / counter;
            MessageBox.Show($"Средний оклад основных сотрудников - {averageSalary}руб.");
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №9\n" +
                "Morar Vlad ИСП-34\n" +
                "Заполнить таблицу со списком сотрудников на 7 человек с полями: ФИО, пол, " +
                "должность, стаж работы, оклад.Вывести результат на экран.Вывести средний оклад.", "О программе", MessageBoxButton.OK);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
