using System;
using TradeRisk.Interfaces;

namespace TradeRisk.Classes.Categories
{
    class ExpiredCategory : ITradeRiskCategory
    {
        const int MIN_DAYS_TO_BE_EXPIRED = 30;
        public string Description => "EXPIRED";
        public bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).Days > MIN_DAYS_TO_BE_EXPIRED;
        }
    }
}
