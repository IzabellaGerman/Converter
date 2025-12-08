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

namespace Converter
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

        private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
            {
            this.Close();
            }

        private void Minimaze_MouseDown(object sender, MouseButtonEventArgs e)
            {
            this.WindowState = WindowState.Minimized;
            }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
            {
            if (e.ChangedButton == MouseButton.Left)
                {
                this.DragMove();
                }
            }

        private void CurrentFirst_TextChanged(object sender, TextChangedEventArgs e)
            {
          /*  if (CurrencyFirst.Text == 0 | CurrencyFirst.Text != string.Empty)
                {
                    Currency.Text
                } */


            }
        }
    }