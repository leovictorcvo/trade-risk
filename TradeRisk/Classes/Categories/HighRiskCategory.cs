using System;
using TradeRisk.Interfaces;
using TradeRisk.Tools;

namespace TradeRisk.Classes.Categories
{
    class HighRiskCategory : ITradeRiskCategory
    {
        const double MIN_VALUE_TO_BE_HIGHRISK = 1_000_000;
        public override string ToString() => Constants.HIGH_RISK;
        public bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate) =>
            trade.Value > MIN_VALUE_TO_BE_HIGHRISK && trade.ClientSector.ToLower().Equals("private");
    }
}
