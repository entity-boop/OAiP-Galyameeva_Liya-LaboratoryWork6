using System;
using System.Windows;

namespace laba6
{
    public partial class _5 : Window
    {
        public _5()
        {
            InitializeComponent();
        }

        private void Reverse_Matrix(object sender, RoutedEventArgs e)
        {
            ReverseMatrix();
        }

        private void ReverseMatrix()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(InputHeight.Text))
                {
                    MessageBox.Show("Введите высоту!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(InputWidth.Text))
                {
                    MessageBox.Show("Введите ширину!");
                    return;
                }
                if (!int.TryParse(InputHeight.Text, out int height))
                {
                    MessageBox.Show("Пожалуйста, введите в поле высоты число.");
                    return;
                }
                if (!int.TryParse(InputWidth.Text, out int width))
                {
                    MessageBox.Show("Пожалуйста, введите в поле ширины число.");
                    return;
                }

                if (width == height)
                {
                    MessageBox.Show("Матрица не должна быть квадратной.");
                    return;
                }

                Random rand = new Random();
                int[,] matrix = new int[height, width];

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        matrix[i, j] = rand.Next(-10, 11);
                    }
                }

                ShowMatrix.Text = DisplayResults(matrix);

                int[,] reversed = ReflectMatrix(matrix);
                ShowReversedMatrix.Text = DisplayResults(reversed);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        private string DisplayResults(int[,] matrix)
        {
            string result = "";
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result += matrix[i, j].ToString().PadLeft(4) + " ";
                }
                result += "\n";
            }

            return result;
        }

        private int[,] ReflectMatrix(int[,] source)
        {
            int rows = source.GetLength(0);
            int cols = source.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = source[i, cols - 1 - j];
                }
            }

            return result;
        }

        private void GoToNextButton_Click5(object sender, RoutedEventArgs e)
        {
            _6 nextWindow = new _6();

            nextWindow.Show();
        }
    }
}