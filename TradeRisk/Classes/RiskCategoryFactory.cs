using System;
using TradeRisk.Classes.Categories;
using TradeRisk.Interfaces;

namespace TradeRisk.Classes
{
    class RiskCategoryFactory
    {
        private static RiskCategoryFactory _instance;

        public static RiskCategoryFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RiskCategoryFactory();
                }

                return _instance;
            }
        }

        private readonly ITradeRiskCategory[] categories =
        {
            new ExpiredCategory(),
            new HighRiskCategory(),
            new MediumRiskCategory()
        };

        public ITradeRiskCategory GetRiskCategory(ITrade trade, DateTime referenceDate)
        {
            ITradeRiskCategory category = null;
            for (int count = 0; count < categories.Length; count++)
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
