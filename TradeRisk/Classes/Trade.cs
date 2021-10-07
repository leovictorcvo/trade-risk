using System;
using System.Globalization;
using TradeRisk.Interfaces;

namespace TradeRisk.Classes
{
    public class Trade : ITrade
    {
        private enum recordPositions
        {
            value = 0,
            clientSector = 1,
            nextPaymentDate = 2
        };

        private readonly double _value;
        private readonly string _clientSector;
        private readonly DateTime _nextPaymentDate;

        public double Value => _value;

        public string ClientSector => _clientSector;

        public DateTime NextPaymentDate => _nextPaymentDate;

        public Trade(string tradeRecord)
        {
            try
            {
                var values = tradeRecord.Split(' ');
                _value = double.Parse(values[(int)recordPositions.value]);
                _clientSector = values[(int)recordPositions.clientSector];
                _nextPaymentDate = DateTime.ParseExact(values[(int)recordPositions.nextPaymentDate], "MM/dd/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException($"Invalid record format: {tradeRecord}");
            }
        }

        public string RiskCategory(DateTime referenceDate) =>
            RiskCategoryFactory.Instance.GetRiskCategory(this, referenceDate)?.ToString() ?? Tools.Constants.NOT_CATEGORIZED;
    }
}
