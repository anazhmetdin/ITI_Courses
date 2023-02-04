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

namespace ContactInfo
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

        private void Submit(object sender, RoutedEventArgs e)
        {
            var GridTextFields = Grid.Children;

            string messageBoxText = "You have Entered:";
            string caption = "Personal Info";

            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result;

            foreach (var field in GridTextFields)
            {
                if (field is TextBox textBox)
                    messageBoxText += $"\n{textBox.Name.Replace('_', ' ')}: {textBox.Text}";
            }

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);

            if (result == MessageBoxResult.Cancel)
            {
                Cancel(sender, e);
            }
            else if (result == MessageBoxResult.OK)
            {
                messageBoxText = "Data saved successfully";
                caption = "Saving";
                button = MessageBoxButton.OK;
                icon = MessageBoxImage.None;

                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var GridTextFields = Grid.Children;

            foreach (var field in GridTextFields)
            {
                if (field is TextBox textBox)
                    textBox.Text = "";
            }
        }
    }
}
