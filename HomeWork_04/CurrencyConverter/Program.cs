namespace CurrencyConverter
{
    internal class Program
    {
        public static ExchangeRate[] RandomExchangeRateArray(Currencies ourCurrencies)
        {
            Currencies currencies = new Currencies();
            ExchangeRate[] exchangeRates = new ExchangeRate[10];

            Random rand = new Random();

            for (int i = 0; i < exchangeRates.Length; i++)
            {
                currencies = (Currencies)i;
                int random = rand.Next(1, 200);

                if (currencies == ourCurrencies)
                {
                    random = 1;
                }

                ExchangeRate exchangeRate = new(ourCurrencies, currencies, random);
                exchangeRates[i] = exchangeRate;

                Console.WriteLine($"{exchangeRates[i]}");
            }

            return exchangeRates;
        }

        public static int Input()
        {
            string temp = Console.ReadLine();
            int i = 0;

            while (!int.TryParse(temp, out i))
            {
                Console.WriteLine("It is not number! Please,enter a number!");
                temp = Console.ReadLine();
            }

            return i;
        }

        static void Main(string[] args)
        {
            CurrencyConverter currencyConverter = new CurrencyConverter();

            Console.Write("Enter the currency whose exchange rate you want to know: ");
            string ourCurrencies = Console.ReadLine();

            switch (ourCurrencies)
            {
                case "USD":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.USD));
                    break;
                case "EUR":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.EUR));
                    break;
                case "PLN":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.PLN));
                    break;
                case "BTC":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.BTC));
                    break;
                case "CNY":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.CNY));
                    break;
                case "KZT":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.KZT));
                    break;
                case "ITL":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.ITL));
                    break;
                case "UAH":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.UAH));
                    break;
                case "BYN":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.BYN));
                    break;
                case "RUB":
                    currencyConverter.AddExchangeRates(RandomExchangeRateArray(Currencies.RUB));
                    break;
                default:
                    Console.WriteLine("Try again");
                    break;
            }


            Console.Write("Enter currency count:  ");
            int count = Input();

            Console.WriteLine("Convert: " + $"{currencyConverter.Convert(Currencies.RUB, Currencies.USD, count)}");
        }
    }
}