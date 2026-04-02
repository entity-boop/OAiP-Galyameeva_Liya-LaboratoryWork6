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
using System.Windows.Shapes;

namespace laba6
{
    /// <summary>
    /// Логика взаимодействия для _2.xaml
    /// </summary>
    public partial class _2 : Window
    {
        public _2()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            FindPalindromes();
        }

        private void FindPalindromes()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Input_TextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите число.");
                    return;
                }
                if (!int.TryParse(Input_TextBox.Text, out int N) || N <= 1)
                {
                    MessageBox.Show("Введите корректное натуральное число больше 1.");
                    return;
                }

                StringBuilder result = new StringBuilder();
                int count = 0;

                for (int i = 1; i < N; i++)
                {
                    if (IsPalindrome(i))
                    {
                        result.Append(i + " ");
                        count++;

                        if (count % 10 == 0)
                        {
                            result.AppendLine();
                        }
                    }
                }
                if (count == 0)
                {
                    ResultTextBlock.Text = $"Палиндромов меньше {N} не найдено.";
                }
                else
                {
                    ResultTextBlock.Text = $"Найдено палиндромов: {count}\n\n{result.ToString()}";
                }

            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
            }
        }
        private bool IsPalindrome(int number)
        {
            if (number < 0)
            {
                MessageBox.Show("Число должно быть положительным.");
                return false;
            }

            int original = number;
            int reversed = 0;

            while (number > 0)
            {
                int lastDigit = number % 10;           // Получаем последнюю цифру
                reversed = reversed * 10 + lastDigit;  // Добавляем её в обратное число
                number /= 10;                           // Убираем последнюю цифру
            }

            return original == reversed; // Сравниваем исходное число с перевернутым
        }
        private void GoToNextButton_Click2(object sender, RoutedEventArgs e)
        {
            _3 nextWindow = new _3();

            nextWindow.Show();
        }
    }
}

