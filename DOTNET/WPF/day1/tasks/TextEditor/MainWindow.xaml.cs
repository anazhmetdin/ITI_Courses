using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ButtonBase[] EditingBtns;
        public MainWindow()
        {
            InitializeComponent();
            EditingBtns = new ButtonBase[] { LeftAlign, CenterAlign, RightAlign, SetTextBtn,
                ClearBtn, PrependBtn, InsertBtn, AppendBtn, PasteBtn, UndoBtn };
        }

        private void SetText(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true)
                Input.Text = "Replace default text with initial text value";
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            Input.Focus();
            Input.SelectAll();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true)
                Input.Clear();
        }

        private void Prepend(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true)
                Input.Text = "*** Prepended text *** " + Input.Text;
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true)
                Input.Text = Input.Text.Insert(Input.CaretIndex, " *** inserted text *** ");
        }

        private void Append(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true)
                Input.Text += " *** appended text ***";
        }

        private void Cut(object sender, RoutedEventArgs e)
        {
            if (Input.SelectedText == "")
            {
                string messageBoxText = $"Select text to { (Editable.IsChecked == true ? "cut" : "copy") } first";
                string caption = "Empty Selection";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.None;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            }
            else
            {
                if (Editable.IsChecked == true)
                    Input.Cut();
                else
                    Input.Copy();
            }
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true)
                Input.Paste();
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true)
                Input.Undo();
        }

        private void HorizontalAlign(object sender, RoutedEventArgs e)
        {
            if (Editable.IsChecked == true && sender is RadioButton btn)
                switch (btn.Name)
                {
                    case "LeftAlign":
                        Input.HorizontalContentAlignment = HorizontalAlignment.Left;
                        break;
                    case "CenterAlign":
                        Input.HorizontalContentAlignment = HorizontalAlignment.Center;
                        break;
                    case "RightAlign":
                        Input.HorizontalContentAlignment = HorizontalAlignment.Right;
                        break;
                }
        }

        private void AdjustAlign(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton s && s != null && EditingBtns != null)
            {
                foreach (var child in EditingBtns)
                {
                   child.IsEnabled = Editable.IsChecked == true;
                }

                if (s.Name == "Editable")
                {
                    CutBtn.Content = "Cut";
                    Input.IsReadOnly = false;
                }
                else
                {
                    CutBtn.Content = "Copy";
                    Input.IsReadOnly = Input.IsReadOnlyCaretVisible = true;
                }
            }
        }
    }
}
