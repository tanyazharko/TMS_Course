using System.Text;

namespace CurrencyConverter
{
    internal class CurrencyConverter
    {
        private List<ExchangeRate> _exchangeRates;

        public CurrencyConverter()
        {
            _exchangeRates = new List<ExchangeRate>();
        }

        public void AddExchangeRate(ExchangeRate exchangeRates)
        {
            _exchangeRates.Add(exchangeRates);
        }

        public void AddExchangeRates(ExchangeRate[] exchangeRates)
        {
            _exchangeRates.AddRange(exchangeRates);
        }

        public void TryDeleteExchangeRate(Currencies firstCurrency, Currencies secondCurrency)
        {
            for (int i = 0; i < _exchangeRates.Count; i++)
            {
                if (_exchangeRates[i].FirstCurrency == firstCurrency && _exchangeRates[i].SecondCurrency == secondCurrency)
                {
                    _exchangeRates.Remove(_exchangeRates[i]);
                }
            }
        }

        public ExchangeRate FindExchangeRate(Currencies firstCurrency, Currencies secondCurrency)
        {
            ExchangeRate? findExchangeRate = null;

            foreach (ExchangeRate exchangeRate in _exchangeRates)
            {
                if (exchangeRate.FirstCurrency == firstCurrency && exchangeRate.SecondCurrency == secondCurrency)
                {
                    findExchangeRate = exchangeRate;
                }
            }

            return findExchangeRate;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ExchangeRate exchangeRate in _exchangeRates)
            {
                sb.Append(exchangeRate.ToString());
            }

            return sb.ToString();
        }

        public ExchangeRate Convert(Currencies currcencyFirst, Currencies currencySecond, int count)
        {
            ExchangeRate findExchangeRate = FindExchangeRate(currcencyFirst, currencySecond);

            ExchangeRate result = new ExchangeRate(currcencyFirst, currencySecond);
            result.СurrencyCount = count;
            result.Value = count * findExchangeRate.Value;

            return result;
        }
    }
}
