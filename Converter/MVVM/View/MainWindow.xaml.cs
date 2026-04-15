using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Converter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Minimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void CurrencyBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "0")
            {
                textBox.Text = "";
            }

            // Only allow digits and one decimal separator
            if (sender is TextBox tb)
            {
                bool isDot = e.Text == "." || e.Text == ",";
                bool isDigit = char.IsDigit(e.Text[0]);

                if (!isDigit && !isDot)
                    e.Handled = true;
                else if (isDot && (tb.Text.Contains('.') || tb.Text.Contains(',')))
                    e.Handled = true;
            }
        }

        private void CurrencyBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
    }
}
