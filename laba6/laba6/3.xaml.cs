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
    /// Логика взаимодействия для _3.xaml
    /// </summary>
    public partial class _3 : Window
    {
        public _3()
        {
            InitializeComponent();
        }
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateArrayElements();
        }
        private void CalculateArrayElements()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Input_TextBox.Text))
                {
                    MessageBox.Show("Введите элементы массива!");
                    return;
                }

                string[] parts = Input_TextBox.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                double[] numbers = new double[parts.Length];
                int positive = 0;
                int negative = 0;
                int zero = 0;

                for (int i = 0; i < parts.Length; i++)
                {
                    numbers[i] = Convert.ToDouble(parts[i]);

                    if (numbers[i] > 0)
                        positive++;
                    else if (numbers[i] < 0)
                        negative++;
                    else
                        zero++;
                }
                PositiveCountText.Text = positive.ToString();
                NegativeCountText.Text = negative.ToString();
                ZeroCountText.Text = zero.ToString();

            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка! Вводите только числа через пробел.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private void GoToNextButton_Click3(object sender, RoutedEventArgs e)
        {
            _4 nextWindow = new _4();

            nextWindow.Show();
        }
    }
}
