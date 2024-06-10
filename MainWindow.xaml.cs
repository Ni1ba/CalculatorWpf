using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{

    public partial class MainWindow : Window
    {



        //значение полей в калькуляторе
        public double _firstValue;
        public double _secondValue;
        public string _action;
        public string _resultValue;
        public TextBox _activeValue;
        private bool _firstValuePointEnable;
        private bool _secondValuePointEnable;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
                                    
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus(); // Установить фокус на окно
        }

       

            //получение данных с wpf
            public void RetrieveDataFromXmlFields()
        {
            _firstValue = TextBoxToDouble(firstValue);
            _secondValue = TextBoxToDouble(secondValue);
            _action = TextBlockToSring(action);
        }
        //вычисление
        public void doResult()
        {
            result.Clear();

            switch (_action)
            {
                case "+":
                    result.AppendText(DoubleToTextBox(_firstValue + _secondValue));

                    return;
                case "-":
                    result.AppendText(DoubleToTextBox(_firstValue - _secondValue));
                    return;
                case "*":
                    result.AppendText(DoubleToTextBox(_firstValue * _secondValue));
                    return;
                case "/":
                    if (_secondValue == 0)
                    {
                        result.AppendText("\r\n\u221E");
                    }
                    else
                    {
                        result.AppendText(DoubleToTextBox(_firstValue / _secondValue));
                    }
                    return;

            }
        }

        //double в текст
        private string DoubleToTextBox(double number)
        {
            return number.ToString();
        }
        //текстбокс в дабл конвертация
        private double TextBoxToDouble(TextBox textBox)
        {
            if (double.TryParse(textBox.Text, out double result))
            {
                return result;
            }
            return 0;
        }
        ///текстбокс в строку
        //private string TextBoxToString(TextBox textBox)
        //{
        //    return textBox.Text;
        //}

        private string TextBlockToSring(TextBlock textBlock)
        {
            return textBlock.Text;
        }

        //---------------------Кнопки
        private void SetActionSymbol(string symbol)
        {
            action.Text = string.Empty;
            action.Text += symbol;
        }

        private void BDivide_Click(object sender, RoutedEventArgs e)
        {
            SetActionSymbol("/");
        }
        private void BMulti_Click(object sender, RoutedEventArgs e)
        {
            SetActionSymbol("*");
        }
        private void Bminus_Click(object sender, RoutedEventArgs e)
        {
            SetActionSymbol("-");
        }
        private void BPlus_Click(object sender, RoutedEventArgs e)
        {
            SetActionSymbol("+");
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            action.Text = string.Empty;
            firstValue.Clear();
            secondValue.Clear();
            result.Clear();
            _firstValuePointEnable = false;
            _secondValuePointEnable = false;
            //test.Text = string.Empty;
        }
        private void BEql_Click(object sender, RoutedEventArgs e)
        {
            RetrieveDataFromXmlFields();
            doResult();
        }

        private void BPoint_Click(object sender, RoutedEventArgs e)
        {
            if (action.Text != string.Empty && _secondValuePointEnable!=true)
            {
                if (secondValue.Text != string.Empty)
                {
                    secondValue.AppendText(",");
                    _secondValuePointEnable = true;
                }
                else
                {
                    secondValue.AppendText("0,");
                    _secondValuePointEnable = true;
                }

            }
            else if (_firstValuePointEnable != true)
            {
                if (firstValue.Text != string.Empty)
                {
                    firstValue.AppendText(",");
                    _firstValuePointEnable = true;
                }
                else
                {
                    firstValue.AppendText("0,");
                    _firstValuePointEnable = true;
                }
            }

        }
        private void ActiveValuesReturn()
        {
            if (action.Text != string.Empty)
            {
                _activeValue = secondValue;

            }

            else
            {
                _activeValue = firstValue;
            }
        }



        // ------------- Цифры
               
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("1");
        }
        private void B2_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("2");
            
        }
        private void B3_Click(object sender, RoutedEventArgs e)
        {

            ActiveValuesReturn();
            _activeValue.AppendText("3");
        }
     
        private void B4_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("4");
        }
        private void B5_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("5");
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("6");
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("8");
        }
        private void B7_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("7");
        }
        private void B9_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("9");
        }
        private void B0_Click(object sender, RoutedEventArgs e)
        {
            ActiveValuesReturn();
            _activeValue.AppendText("0");
        }

    }
}