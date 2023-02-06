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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double currentNum = 0;
        private string currentStr = "";
        private Stack<double> operands = new();
        private Stack<string> operators = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EditNumber(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn != null)
            {
                double temp;
                if (Double.TryParse(currentStr + btn.Content, out temp) && (temp != currentNum || (temp == 0 && currentStr == "") || btn.Content as string == "."))
                {
                    Screen.Text += btn.Content;
                    currentStr += btn.Content;
                    currentNum = temp;
                }
            }
        }

        private void AddOperator(object sender, RoutedEventArgs e)
        {

            if (sender is Button btn && btn != null)
            {
                string content = (string)btn.Content;

                AddNumber();

                Screen.Text += content;

                HandleOperator(content);

            }
        }

        private void AddNumber()
        {
            if (currentStr != "")
            {
                operands.Push(currentNum);

                currentNum = 0;
                currentStr = "";
            }
        }

        private void HandleOperator(string content)
        {
            if (content == ")")
            {
                while (operators.Count > 0 && operators.Peek() != "(")
                {
                    TryEvaluateTopOperation();
                }

                operators.Pop();
            }
            else
            {
                if (content != "(")
                {
                    while (operators.Count > 0 && EvaluateOperator(operators.Peek()) < EvaluateOperator(content))
                    {
                        TryEvaluateTopOperation();
                    }
                }

                operators.Push(content);
            }
        }

        private double Evaluate(double operand1, double operand2, string topOperator)
        {
            if (topOperator == "+") return operand1 + operand2;
            else if (topOperator == "-") return operand1 - operand2;
            else if (topOperator == "x") return operand1 * operand2;
            else
            {
                if (operand2 == 0) throw new Exception();
                return operand1 / operand2;
            }
        }

        private void reset()
        {
            currentNum = 0;
            currentStr = Screen.Text = "";
            operators.Clear();
            operands.Clear();
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private int EvaluateOperator(string op)
        {
            if (op == "-" || op == "+")
            {
                return 0;
            }
            else if (op == "*" || op == "/")
            { 
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private void EvaluateTopOperation()
        {
            string topOperator = operators.Pop();
            double operand2 = operands.Pop();
            double operand1 = operands.Pop();

            double operand3 = Evaluate(operand1, operand2, topOperator);
            operands.Push(operand3);
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            AddNumber();

            while (operators.Count > 0)
            {
                TryEvaluateTopOperation();
            }

            if (operators.Count == 0 && operands.Count == 1)
            {
                currentNum = operands.Pop();
                Screen.Text = currentStr = currentNum.ToString();
            }
            else if (operands.Count() != 0)
            {
                string messageBoxText = "Invalid Expression";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
            }
        }

        private void TryEvaluateTopOperation()
        {
            try
            {
                EvaluateTopOperation();
            }
            catch
            {
                string messageBoxText = "Can't Divide by 0";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);

                reset();
            }
        }
    }
}
