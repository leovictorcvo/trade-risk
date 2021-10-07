using System;
using TradeRisk.Classes.Categories;
using TradeRisk.Interfaces;

namespace TradeRisk.Classes
{
    class RiskCategoryFactory
    {
        private ITradeRiskCategory[] categories =
        {
            new ExpiredCategory(),
            new HighRiskCategory(),
            new MediumRiskCategory()
        };
        
        public ITradeRiskCategory GetRiskCategory(ITrade trade, DateTime referenceDate)
        {
            ITradeRiskCategory category = null;
            for(int count = 0; count < categories.Length; count++)
            {
                if (categories[count].IsTradeFromThisRiskCategory(trade, referenceDate))
                {
                    category = categories[count];
                    break;
                }
            }
            return category;
        }
    }
}
