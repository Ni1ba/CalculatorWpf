using System.Windows;
using System.Windows.Controls;

namespace Calculator
{

    public partial class MainWindow : Window
    {
       

        //поля в калькуляторе
        public double _firstValue;
        public double _secondValue;
        public string _action;
        public string _resultValue;


        public MainWindow()
        {
            InitializeComponent();
           
            _firstValue = 0;
            
            
        }
        


        //получение данных с wpf 
        public void RetrieveDataFromXmlFields()
        {
            _firstValue = TextBoxToDouble(firstValue);
            _secondValue = TextBoxToDouble(secondValue);
            _action = TextBoxToString(action);
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
                        result.AppendText("ERROR");
                        return;
                    }
                    else
                    {
                        result.AppendText(DoubleToTextBox(_firstValue / _secondValue));
                        return;
                    }
                   
            }
        }

        //  double в текст 
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
        //текстбокс в строку 
        private string TextBoxToString(TextBox textBox)
        {
            return textBox.Text;
        }





        //---------------------Кнопки
        private void BDivide_Click(object sender, RoutedEventArgs e)
        {
            action.Clear();
            action.AppendText("/");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RetrieveDataFromXmlFields();
            doResult();
        }

        private void BMulti_Click(object sender, RoutedEventArgs e)
        {
            action.Clear();
            action.AppendText("*");
        }

        private void Bminus_Click(object sender, RoutedEventArgs e)
        {
            action.Clear();
            action.AppendText("-");
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            action.Clear();
            firstValue.Clear();
            secondValue.Clear();
            result.Clear();
        }

        private void BPlus_Click(object sender, RoutedEventArgs e)
        {
            action.Clear();
            action.AppendText("+");
        }

        private void BEql_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            firstValue.AppendText("3");
        }
    }
}