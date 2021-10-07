using System;
using System.Collections.Generic;
using System.Globalization;
using TradeRisk.Interfaces;
using TradeRisk.Tools;

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
            if (string.IsNullOrWhiteSpace(tradeRecord))
            {
                throw new ArgumentException("Empty record found");
            }
            
            var values = tradeRecord.Split(' ');
            
            if (values.Length < Enum.GetNames<recordPositions>().Length)
            {
                throw new ArgumentException($"Invalid record format: {tradeRecord}");
            }
            
            if (!double.TryParse(values[(int)recordPositions.value], out _value))
            {
                throw new ArgumentException($"Invalid amount value: {tradeRecord}");
            }
            
            _clientSector = values[(int)recordPositions.clientSector].ToUpper();
            
            if ((new List<string> { Constants.PRIVATE_SECTOR, Constants.PUBLIC_SECTOR}).IndexOf(_clientSector) == -1)
            {
                throw new ArgumentException($"Invalid sector name: {tradeRecord}. Should be {Constants.PRIVATE_SECTOR} or {Constants.PUBLIC_SECTOR}");
            }

            if (!DateTime.TryParseExact(values[(int)recordPositions.nextPaymentDate], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _nextPaymentDate))
            {
                throw new ArgumentException($"Invalid next payment date value: {tradeRecord}");
            }
        }

        public string RiskCategory(DateTime referenceDate) =>
            RiskCategoryFactory.Instance.GetRiskCategory(this, referenceDate)?.ToString() ?? Tools.Constants.NOT_CATEGORIZED;
    }
}
