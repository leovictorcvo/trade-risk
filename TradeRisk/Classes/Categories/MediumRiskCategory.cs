using System;
using TradeRisk.Interfaces;
using TradeRisk.Tools;

namespace TradeRisk.Classes.Categories
{
    class MediumRiskCategory : ITradeRiskCategory
    {
        const double MIN_VALUE_TO_BE_MEDIUMRISK = 1_000_000;
        public override string ToString() => Constants.MEDIUM_RISK;
        public bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate) =>
            trade.Value > MIN_VALUE_TO_BE_MEDIUMRISK && trade.ClientSector.ToLower().Equals("public");
    }
}
