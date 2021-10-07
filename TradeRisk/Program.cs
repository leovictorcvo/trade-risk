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
                (DateTime referenceDate, Trade[] trades) = ShowInstructionsAndGetData();
                ShowTradeCategories(trades, referenceDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("*******");
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("*******");
            }
        }

        static (DateTime, Trade[]) ShowInstructionsAndGetData()
        {
            string answer;
            DateTime referenceDate;
            int numberOfTradesInPortfolio;
            Trade[] trades;

            Console.Clear();
            Console.WriteLine("Trade risk calculator");
            Console.WriteLine("---------------------");
            Console.Write("Reference date (mm/dd/yyyy): ");
            answer = Console.ReadLine();
            if (!DateTime.TryParseExact(answer, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out referenceDate))
            {
                throw new ArgumentException("Invalid reference date");
            }
            Console.Write("Number of trades in portfolio: ");
            answer = Console.ReadLine();
            if (!int.TryParse(answer, out numberOfTradesInPortfolio))
            {
                throw new ArgumentException("Invalid number of trades");
            }
            trades = new Trade[numberOfTradesInPortfolio];
            for (int tradeNumber = 0; tradeNumber < numberOfTradesInPortfolio; tradeNumber++)
            {
                Console.Write($"Trade info {tradeNumber + 1} of {numberOfTradesInPortfolio}: ");
                answer = Console.ReadLine();
                trades[tradeNumber] = new Trade(answer);
            }
            return (referenceDate, trades);
        }
        static void ShowTradeCategories(Trade[] trades, DateTime referenceDate)
        {
            foreach(Trade trade in trades)
            {
                Console.WriteLine(trade.RiskCategory(referenceDate));
            };
        }
    }
}
