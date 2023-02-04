using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InkCanvas
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

        private void New(object sender, RoutedEventArgs e)
        {
            Canvas.Strokes.Clear();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName,
                                               FileMode.Create);
                Canvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "isf files (*.isf)|*.isf";

            if (saveFileDialog1.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName,
                                               FileMode.Create);
                Canvas.Strokes = new StrokeCollection(fs);
                fs.Close();
            }
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            Canvas.CopySelection();
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            Canvas.Paste();
        }

        private void Cut(object sender, RoutedEventArgs e)
        {
            Canvas.CutSelection();
        }

        private void BrushColor(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton color && color != null)
            {
                switch (color.Content)
                {
                    case "Black":
                        Canvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromRgb(0, 0, 0);
                        break;
                    case "Red":
                        Canvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromRgb(255, 0, 0);
                        break;
                    case "Green":
                        Canvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromRgb(0, 255, 0);
                        break;
                    case "Blue":
                        Canvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromRgb(0, 0, 255);
                        break;
                    case "Magenta":
                        Canvas.DefaultDrawingAttributes.Color = System.Windows.Media.Color.FromRgb(255, 0, 255);
                        break;
                }
            }
        }

        private void BrushMode(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton mode && mode != null)
            {
                switch (mode.Content)
                {
                    case "Erase":
                        Canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                        break;
                    case "Erase by stroke":
                        Canvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                        break;
                    case "Select":
                        Canvas.EditingMode = InkCanvasEditingMode.Select;
                        break;
                    case "Ink":
                        Canvas.EditingMode = InkCanvasEditingMode.Ink;
                        break;
                }
            }
        }

        private void BrushShape(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton shape && shape != null)
            {
                switch (shape.Content)
                {
                    case "Ellipse":
                        Canvas.DefaultDrawingAttributes.StylusTip = StylusTip.Ellipse;
                        break;
                    case "Rectangle":
                        Canvas.DefaultDrawingAttributes.StylusTip = StylusTip.Rectangle;
                        break;
                }
            }
        }

        private void BrushSize(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton size && size != null)
            {
                switch (size.Content)
                {
                    case "Small":
                        Canvas.DefaultDrawingAttributes.Width = Canvas.DefaultDrawingAttributes.Height = 1;
                        break;
                    case "Normal":
                        Canvas.DefaultDrawingAttributes.Width = Canvas.DefaultDrawingAttributes.Height = 3;
                        break;
                    case "Large":
                        Canvas.DefaultDrawingAttributes.Width = Canvas.DefaultDrawingAttributes.Height = 8;
                        break;
                }
            }
        }
    }
}
