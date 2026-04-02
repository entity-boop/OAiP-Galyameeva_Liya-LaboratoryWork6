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
    /// Логика взаимодействия для _4.xaml
    /// </summary>
    public partial class _4 : Window
    {
        public _4()
        {
            InitializeComponent();
        }

        private void Check_Double(object sender, RoutedEventArgs e)
        {
            ProcessNumbers();
        }
        private void ProcessNumbers()
        {
            try
            {
                TextBox[] inputs = { Num1TextBox, Num2TextBox, Num3TextBox, Num4TextBox, Num5TextBox };

                //проверка на запооение
                for (int i = 0; i < inputs.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(inputs[i].Text))
                    {
                        MessageBox.Show($"Введите число {i + 1}!");
                        return;
                    }
                }

                double[] numbers = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    if (!double.TryParse(inputs[i].Text, out numbers[i]))
                    {
                        MessageBox.Show($"Число {i + 1} введено некорректно!");
                        return;
                    }
                }

                int[,] matrix = new int[5, 3];

                for (int i = 0; i < 5; i++)
                {
                    // число по модулю
                    double absNumber = Math.Abs(numbers[i]);

                    // целая часть
                    int intPart = (int)absNumber;
                    matrix[i, 0] = intPart;

                    // дробная часть
                    double fractional = absNumber - intPart;
                    int fractionalPart = (int)(fractional * 100000 + 0.5);
                    matrix[i, 1] = fractionalPart;

                    // 0 - полож, 1 - отриц
                    matrix[i, 2] = numbers[i] >= 0 ? 0 : 1;
                }
                DisplayResults(matrix);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private string GetSign(int signValue)
        {
            return signValue == 0 ? "+" : "-";
        }
        private void DisplayResults(int[,] matrix)
        {
            // cтрока 1
            Row1Int.Text = matrix[0, 0].ToString();
            Row1Frac.Text = matrix[0, 1].ToString("D5");
            Row1Sign.Text = GetSign(matrix[0, 2]);

            // cтрока 2
            Row2Int.Text = matrix[1, 0].ToString();
            Row2Frac.Text = matrix[1, 1].ToString("D5");
            Row2Sign.Text = GetSign(matrix[1, 2]);

            // cтрока 3
            Row3Int.Text = matrix[2, 0].ToString();
            Row3Frac.Text = matrix[2, 1].ToString("D5");
            Row3Sign.Text = GetSign(matrix[2, 2]);

            // cтрока 4
            Row4Int.Text = matrix[3, 0].ToString();
            Row4Frac.Text = matrix[3, 1].ToString("D5");
            Row4Sign.Text = GetSign(matrix[3, 2]);

            // cтрока 5
            Row5Int.Text = matrix[4, 0].ToString();
            Row5Frac.Text = matrix[4, 1].ToString("D5");
            Row5Sign.Text = GetSign(matrix[4, 2]); 
        }

        private void GoToNextButton_Click4(object sender, RoutedEventArgs e)
        {
            _5 nextWindow = new _5();

            nextWindow.Show();
        }
    }
}