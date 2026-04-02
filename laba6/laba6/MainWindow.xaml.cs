using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace laba6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Check_first_event_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Age_of_first_event.Text))
                {
                    MessageBox.Show("Пожалуйста, введите ваш возраст.");
                    return;
                }
                if (!int.TryParse(Age_of_first_event.Text, out int age))
                {
                    MessageBox.Show("Пожалуйста, введите корректное число.");
                    return;
                }
                if (age < 0 || age > 150)
                {
                    MessageBox.Show("Пожалуйста, введите корректный возраст (от 0 до 150 лет).");
                    return;
                }
                if (age >= 8)
                {
                    MessageBox.Show($"Возраст подходит для посещения мастер-класса!");
                }
                else
                {
                    MessageBox.Show($"Возраст не подходит для посещения мастер-класса!");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }
        private void GoToNextButton_Click(object sender, RoutedEventArgs e)
        {
            _2 nextWindow = new _2();

            nextWindow.Show();
        }
    }
}