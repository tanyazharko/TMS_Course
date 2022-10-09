using System.Diagnostics;

namespace Task_01
{
    internal class Program
    {
        public static int MaxProfit(int[] prices)
        {
            int minBuyShareOnePrice = int.MaxValue;
            int maxShareOneProfitAfterSelling = 0;
            int minBuyShareTwoPrice = int.MaxValue;
            int maxShareTwoProfitAfterSelling = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                int currentPrice = prices[i];

                minBuyShareOnePrice = Math.Min(minBuyShareOnePrice, currentPrice);
                maxShareOneProfitAfterSelling = Math.Max(maxShareOneProfitAfterSelling, currentPrice - minBuyShareOnePrice);

                minBuyShareTwoPrice = Math.Min(minBuyShareTwoPrice, currentPrice - maxShareOneProfitAfterSelling);
                maxShareTwoProfitAfterSelling = Math.Max(maxShareTwoProfitAfterSelling, currentPrice - minBuyShareTwoPrice);
            }

            return maxShareTwoProfitAfterSelling;
        }

        static void Main(string[] args)
        {
            int[] prices = { 3, 3, 5, 0, 0, 3, 1, 4 };

            int maxProfit = MaxProfit(prices);

            Console.WriteLine(maxProfit);
        }
    }
}

//You are given an array prices where prices[i] is the price of a given stock on the ith day.

//Find the maximum profit you can achieve. You may complete at most two transactions.

//Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).


//Example 1:

//Input: prices = [3, 3, 5, 0, 0, 3, 1, 4]
//Output: 6
//Explanation: Buy on day 4(price = 0) and sell on day 6 (price = 3), profit = 3 - 0 = 3.
//Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4 - 1 = 3.

