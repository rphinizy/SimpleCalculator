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

namespace SimpleCalculator
{
 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        // variables for storing and calculating user inputs
        private double _operand1;
        private double _operand2;
        private float _operand3;
        private double _answer;
        private double answer = 0;
        
        private bool _add = false;
        private bool _subtract = false;
      
        private string userEntry1;

        public CalculatorWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculator button click event handler for 0-9 and decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Numbers_Click(object sender, RoutedEventArgs e)
        {
            Button operationButton = (Button)sender;
            string operation = operationButton.Name;
            Label_Combo_Box.Content = "";

            switch (operation)
            {
                case "button_Decimal":
                    userEntry1 = userEntry1 + ".";
                    label_answer.Content = userEntry1;
                    break;

                case "button_Zero":
                    userEntry1 = userEntry1 + 0;
                    label_answer.Content = userEntry1;
                    break;

                case "button_One":
                    userEntry1 = userEntry1 + 1;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Two":
                    userEntry1 = userEntry1 + 2;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Three":
                    userEntry1 = userEntry1 + 3;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Four":
                    userEntry1 = userEntry1 + 4;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Five":
                    userEntry1 = userEntry1 + 5;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Six":
                    userEntry1 = userEntry1 + 6;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Seven":
                    userEntry1 = userEntry1 + 7;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Eight":
                    userEntry1 = userEntry1 + 8;
                    label_answer.Content = userEntry1;
                    break;

                case "button_Nine":
                    userEntry1 = userEntry1 + 9;
                    label_answer.Content = userEntry1;
                    break;

                default:
                    break;
            }
        }
        
        /// <summary>
        /// Calculator button click event handler for operational buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            Button operationButton = (Button)sender;
            string operation = operationButton.Name;
            Label_Combo_Box.Content = "";

            switch (operation)
            {
                case "button_Add":
                    double.TryParse(userEntry1, out _operand1);
                    _add = true;
                    _subtract = false;
                    label_answer.Content = "";
                    userEntry1 = "";
                    break;

                case "button_Sub":
                    double.TryParse(userEntry1, out _operand1);
                    _subtract = true;
                    _add = false;
                    label_answer.Content = "";
                    userEntry1 = "";
                    break;

                case "button_Equal":
                    if (_add == true)
                    {
                        double.TryParse(userEntry1, out _operand2);
                        answer = _answer + _operand1 + _operand2;
                        userEntry1 = "";
                        _operand1 = 0;
                        _operand2 = 0;
                        _answer = answer;
                        label_answer.Content = answer.ToString();
                    }

                    if (_subtract == true)
                    {
                        double.TryParse(userEntry1, out _operand2);
                        answer = _answer - _operand1 - _operand2;
                        userEntry1 = "";
                        _operand1 = 0;
                        _operand2 = 0;
                        _answer = answer;
                        _add = false;
                        _subtract = false;
                        label_answer.Content = answer.ToString();
                    }
                    break;

                case "button_Clear":
                    userEntry1 = "";
                    _operand1 = 0;
                    _operand2 = 0;
                    _answer = 0;
                    answer = 0;
                    label_answer.Content = answer.ToString();
                    textBox_Value.Text = String.Empty;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Alternative button click event handler for square root / circumference options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculate_Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            label_answer.Content = "";

            string rootType = ComboBox_Root.SelectionBoxItem as string;
            string userFeedback;

            if (ValidInputs(out userFeedback))
            {
                switch (rootType)
                {
                    case "Square Root":
                        answer = Math.Sqrt(_operand3);
                        Label_Combo_Box.Content = "Square Root";
                        break;

                    case "Circumference":
                        answer = 2*Math.PI*_operand3;
                        Label_Combo_Box.Content = "Circumference";
                        break;

                    default:
                        answer = 0;
                        break;
                }

                label_answer.Content = answer.ToString();
            }
            else
            {
                label_answer.Content = userFeedback;
                MessageBox.Show(userFeedback);
            }

        }

        /// <summary>
        /// User input validation for text box
        /// </summary>
        /// <param name="userFeedback"></param>
        /// <returns></returns>
        private bool ValidInputs(out string userFeedback)
        {
            bool validInputs = true;
            userFeedback = "";
            
            if (!float.TryParse(textBox_Value.Text, out _operand3))
            {
                validInputs = false;
                userFeedback += "ERR CHK operand 2\n";
            }

            return validInputs;
        }

        /// <summary>
        /// Help menu button event handler: See HelpWindow.xaml & HelpWindow.xaml.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        /// <summary>
        /// Exit button event handler closes the corresponding window. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}