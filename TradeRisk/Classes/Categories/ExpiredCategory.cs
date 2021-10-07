using System;
using TradeRisk.Interfaces;
using TradeRisk.Tools;

namespace TradeRisk.Classes.Categories
{
    class ExpiredCategory : ITradeRiskCategory
    {
        const int MIN_DAYS_TO_BE_EXPIRED = 30;
        public override string ToString() => Constants.EXPIRED;
        public bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate) =>
            (referenceDate - trade.NextPaymentDate).Days > MIN_DAYS_TO_BE_EXPIRED;

    }
}
