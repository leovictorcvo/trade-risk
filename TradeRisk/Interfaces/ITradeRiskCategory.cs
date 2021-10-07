using System;

namespace TradeRisk.Interfaces
{
    interface ITradeRiskCategory
    {
        bool IsTradeFromThisRiskCategory(ITrade trade, DateTime referenceDate); //return true if trade was qualified as this risk category
        string Description { get; } //indicates this trade category description 
    }
}
