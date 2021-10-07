using System;
using System.Collections.Generic;
using System.Globalization;
using TradeRisk.Classes;

namespace TradeRisk
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                (DateTime referenceDate, List<Trade> trades) = ShowInstructionsAndGetData();
                ShowTradeCategories(trades, referenceDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("*******");
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("*******");
            }
        }

        static (DateTime, List<Trade>) ShowInstructionsAndGetData()
        {
            string answer;
            DateTime referenceDate;
            int numberOfTradesInPortfolio;
            List<Trade> trades;

            Console.Clear();
            Console.WriteLine("Trade risk calculator");
            Console.WriteLine("---------------------");
            Console.Write("Reference date: ");
            answer = Console.ReadLine();
            referenceDate = DateTime.ParseExact(answer, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Number of trades in portfolio: ");
            answer = Console.ReadLine();
            numberOfTradesInPortfolio = int.Parse(answer);
            trades = new List<Trade>();
            for (int tradeNumber = 0; tradeNumber < numberOfTradesInPortfolio; tradeNumber++)
            {
                Console.Write($"Trade info {tradeNumber + 1} of {numberOfTradesInPortfolio}: ");
                answer = Console.ReadLine();
                trades.Add(new Trade(answer));
            }
            return (referenceDate, trades);
        }
        static void ShowTradeCategories(List<Trade> trades, DateTime referenceDate)
        {
            trades.ForEach(trade =>
            {
                Console.WriteLine(trade.RiskCategory(referenceDate));
            });
        }
    }
}
