using System;

namespace TradeRisk.Interfaces
{
    public interface ITradeRiskCategory
    {
        bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate); //return true if trade was qualified as this risk category
    }
}
