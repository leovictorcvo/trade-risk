using System;
using System.Globalization;
using TradeRisk.Classes;
using TradeRisk.Interfaces;
using TradeRisk.Tools;
using Xunit;

namespace TradeRiskTestProject
{
    public class TradeTest
    {
        private DateTime referenceDate = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture);
        [Fact]
        public void ShouldParseTradeAsExpired()
        {
            string record = "400000 Public 07/01/2020";

            ITrade trade = new Trade(record);

            Assert.Equal(400_000, trade.Value);
            Assert.Equal("Public", trade.ClientSector);
            Assert.Equal(DateTime.ParseExact("07/01/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), trade.NextPaymentDate);
            Assert.Equal(Constants.EXPIRED, trade.RiskCategory(referenceDate).ToString());
        }
        [Fact]
        public void ShouldParseTradeAsHighRisk()
        {
            string record = "2000000 Private 12/29/2025";

            ITrade trade = new Trade(record);

            Assert.Equal(2_000_000, trade.Value);
            Assert.Equal("Private", trade.ClientSector);
            Assert.Equal(DateTime.ParseExact("12/29/2025", "MM/dd/yyyy", CultureInfo.InvariantCulture), trade.NextPaymentDate);
            Assert.Equal(Constants.HIGH_RISK, trade.RiskCategory(referenceDate).ToString());
        }
        [Fact]
        public void ShouldParseTradeAsMediumRisk()
        {
            string record = "5000000 Public 01/02/2024";

            ITrade trade = new Trade(record);

            Assert.Equal(5_000_000, trade.Value);
            Assert.Equal("Public", trade.ClientSector);
            Assert.Equal(DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", CultureInfo.InvariantCulture), trade.NextPaymentDate);
            Assert.Equal(Constants.MEDIUM_RISK, trade.RiskCategory(referenceDate).ToString());
        }
        [Fact]
        public void ShouldParseTradeAsNotCategorized()
        {
            string record = "500000 Public 01/02/2024";

            ITrade trade = new Trade(record);

            Assert.Equal(500_000, trade.Value);
            Assert.Equal("Public", trade.ClientSector);
            Assert.Equal(DateTime.ParseExact("01/02/2024", "MM/dd/yyyy", CultureInfo.InvariantCulture), trade.NextPaymentDate);
            Assert.Equal(Constants.NOT_CATEGORIZED, trade.RiskCategory(referenceDate).ToString());
        }
        [Fact]
        public void ShouldThrowArgumentExceptionOnInvalidRecord()
        {
            string record = "50a Public 30/12/2024";
            void recordParse() => new Trade(record);
            Assert.Throws<ArgumentException>(recordParse);
        }
    }
}
