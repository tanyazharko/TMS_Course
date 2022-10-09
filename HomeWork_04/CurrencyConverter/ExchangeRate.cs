namespace CurrencyConverter
{
    internal class ExchangeRate
    {
        public Currencies FirstCurrency;
        public Currencies SecondCurrency;

        private float _value;
        private int _currencyCount = 1;

        public ExchangeRate(Currencies firstCurrency, Currencies secondCurrency)
        {
            FirstCurrency = firstCurrency;
            SecondCurrency = secondCurrency;
        }

        public ExchangeRate(Currencies firstCurrency, Currencies secondCurrency, float value)
            : this(firstCurrency, secondCurrency)
        {
            _value = value;
        }

        public float Value
        {
            get => _value;
            set => _value = value;
        }

        public int СurrencyCount
        {
            set => _currencyCount = value; 
        }

        public override string ToString()
        {
            string result = string.Concat(string.Format("{0:f2}", _currencyCount), " ", FirstCurrency, " = ",
                string.Format("{0:f2}", _value), " ", SecondCurrency);

            return result;
        }
    }
}
