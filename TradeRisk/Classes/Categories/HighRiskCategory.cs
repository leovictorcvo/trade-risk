using System;
using TradeRisk.Interfaces;

namespace TradeRisk.Classes.Categories
{
    class HighRiskCategory : ITradeRiskCategory
    {
        const double MIN_VALUE_TO_BE_HIGHRISK = 1_000_000;
        public string Description => "HIGHRISK";
        public bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate) =>
            trade.Value > MIN_VALUE_TO_BE_HIGHRISK && trade.ClientSector.ToLower().Equals("private");
    }
}
