using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace laba6
{
    /// <summary>
    /// Логика взаимодействия для _6.xaml
    /// </summary>
    public partial class _6 : Window
    {
        public _6()
        {
            InitializeComponent();
        }

        private void CalculateButton(object sender, RoutedEventArgs e)
        {
            GetSalary();
        }

        private void GetSalary()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(InputSalary.Text))
                {
                    MessageBox.Show("Введите оклад!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(InputDays.Text))
                {
                    MessageBox.Show("Введите количество отработанных дней!");
                    return;
                }

                if (!int.TryParse(InputSalary.Text, out int salary))
                {
                    MessageBox.Show("Пожалуйста, введите в поле высоты число.");
                    return;
                }
                if (!int.TryParse(InputDays.Text, out int days))
                {
                    MessageBox.Show("Пожалуйста, введите в поле ширины число.");
                    return;
                }

                if (MonthsComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите месяц!");
                    return;
                }

                ComboBoxItem selectedMonth = (ComboBoxItem)MonthsComboBox.SelectedItem;
                string monthName = selectedMonth.Content.ToString();
                int monthNumber = int.Parse(selectedMonth.Tag.ToString());

                int daysInMonth = GetDaysInMonth(monthNumber, monthName);

                if (salary <= 0)
                {
                    MessageBox.Show("Оклад должен быть положительным числом!");
                    return;
                }
                if (days <= 0)
                {
                    MessageBox.Show("Количество дней должно быть положительным числом!");
                    return;
                }

                if (days > daysInMonth)
                {
                    MessageBox.Show($"В месяце {monthName} всего {daysInMonth} дней! Вы ввели {days}.");
                    return;
                }

                double result = summa(salary, days, daysInMonth);

                FinalSalary.Text = $"Зарплата за {monthName}: {result:F2} руб.\n" +
                                  $"(Оклад: {salary:F2} руб., отработано: {days} из {daysInMonth} дней)";
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private int GetDaysInMonth(int monthNumber, string monthName)
        {
            switch (monthNumber)
            {
                case 1:  // Январь
                case 3:  // Март
                case 5:  // Май
                case 7:  // Июль
                case 8:  // Август
                case 10: // Октябрь
                case 12: // Декабрь
                    return 31;

                case 4:  // Апрель
                case 6:  // Июнь
                case 9:  // Сентябрь
                case 11: // Ноябрь
                    return 30;
                case 2:  // Февраль
                    return 28;

                default:
                    return 30;
            }

        }

        private double summa(double salary, int workedDays, int daysInMonth)
        {
            return salary / daysInMonth * workedDays;
        }
    }
}
