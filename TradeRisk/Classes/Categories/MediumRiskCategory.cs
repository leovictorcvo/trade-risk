using System;
using TradeRisk.Interfaces;

namespace TradeRisk.Classes.Categories
{
    class MediumRiskCategory : ITradeRiskCategory
    {
        const double MIN_VALUE_TO_BE_MEDIUMRISK = 1_000_000;
        public string Description => "MEDIUMRISK";
        public bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate) =>
            trade.Value > MIN_VALUE_TO_BE_MEDIUMRISK && trade.ClientSector.ToLower().Equals("public");
    }
}
