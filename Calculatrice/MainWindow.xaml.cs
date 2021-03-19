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

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<string> operationArray = new List<string>();

        private void Reset(object sender, RoutedEventArgs e)
        {
            calc.Text = "";
            operatorSign.Content = "";
            operationArray.Clear();
        }

        private void Button_Num(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            calc.Text += button.Content.ToString();
        }

        private void Button_Plus(object sender, RoutedEventArgs e)
        {
            operationArray.Add(Convert.ToString(calc.Text));
            operationArray.Add("+");
            calc.Text = "";
            operatorSign.Content = "+";
        }
        private void Button_Minus(object sender, RoutedEventArgs e)
        {
            operationArray.Add(Convert.ToString(calc.Text));
            operationArray.Add("-");
            calc.Text = "";
            operatorSign.Content = "-";
        }
        private void Button_Multiply(object sender, RoutedEventArgs e)
        {
            operationArray.Add(Convert.ToString(calc.Text));
            operationArray.Add("*");
            calc.Text = "";
            operatorSign.Content = "x";
        }
        private void Button_Divide(object sender, RoutedEventArgs e)
        {
            operationArray.Add(Convert.ToString(calc.Text));
            operationArray.Add("/");
            calc.Text = "";
            operatorSign.Content = "/";
        }

        private void Result(object sender, RoutedEventArgs e)
        {
            bool error = false;
            int total = 0;
            operationArray.Add(Convert.ToString(calc.Text));
            for (int i = 0; i < operationArray.Count; i++)
            {
                if (operationArray[i] == "+")
                {
                    total = Convert.ToInt32(operationArray[i - 1]) + Convert.ToInt32(operationArray[i + 1]);
                    operationArray[i + 1] = Convert.ToString(total);
                }
                if (operationArray[i] == "-")
                {
                    total = Convert.ToInt32(operationArray[i - 1]) - Convert.ToInt32(operationArray[i + 1]);
                    operationArray[i + 1] = Convert.ToString(total);
                }
                if (operationArray[i] == "*")
                {
                    total = Convert.ToInt32(operationArray[i - 1]) * Convert.ToInt32(operationArray[i + 1]);
                    operationArray[i + 1] = Convert.ToString(total);
                }
                if (operationArray[i] == "/")
                {
                    if (Convert.ToInt32(operationArray[i + 1]) == 0)
                    {
                        error = true;
                    }
                    else
                    {
                        total = Convert.ToInt32(operationArray[i - 1]) / Convert.ToInt32(operationArray[i + 1]);
                        operationArray[i + 1] = Convert.ToString(total);

                    }
                }
            }
            if (error)
            {
                calc.Text = "Impossible";
            }
            else
            {
                calc.Text = Convert.ToString(total);
            }
            operatorSign.Content = "=";
            operationArray.Clear();
        }
    }
}
