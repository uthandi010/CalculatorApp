namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        private string _currentInput = string.Empty;
        private string _operator = string.Empty;
        private double _firstNumber, _secondNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDigitClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            _currentInput += button.Text;
            UpdateDisplay();
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            _operator = button.Text;
            _firstNumber = double.Parse(_currentInput);
            _currentInput = string.Empty;
        }

        private void Onpersentageclicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            _operator = button.Text;
            double result = int.Parse(_currentInput) / 100;
            _currentInput = result.ToString();
            UpdateDisplay();
        }
        private void onpositiveclick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            _operator = button.Text;
            double result = double.Parse(_currentInput) * (-1);
            _currentInput = result.ToString();
            UpdateDisplay();
        }

        private void OnDecimalClicked(object sender, EventArgs e)
        {
            if (!_currentInput.Contains("."))
            {
                _currentInput += ".";
                UpdateDisplay();
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            _currentInput = string.Empty;
            _operator = string.Empty;
            _firstNumber = 0;
            _secondNumber = 0;
            UpdateDisplay();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentInput))
            {
                _secondNumber = double.Parse(_currentInput);
                double result = 0;

                switch (_operator)
                {
                    case "+":
                        result = _firstNumber + _secondNumber;
                        break;
                    case "-":
                        result = _firstNumber - _secondNumber;
                        break;
                    case "*":
                        result = _firstNumber * _secondNumber;
                        break;
                    case "/":
                        result = _firstNumber / _secondNumber;
                        break;
                }

                _currentInput = result.ToString();
                UpdateDisplay();
                _operator = string.Empty;
            }
        }

        private void UpdateDisplay()
        {
            DisplayLabel.Text = string.IsNullOrEmpty(_currentInput) ? "0" : _currentInput;
        }

    }

}
