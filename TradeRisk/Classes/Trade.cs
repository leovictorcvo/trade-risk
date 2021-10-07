using System;
using System.Globalization;
using TradeRisk.Interfaces;

namespace TradeRisk.Classes
{
    class Trade : ITrade
    {
        private readonly double _value;
        private readonly string _clientSector;
        private readonly DateTime _nextPaymentDate;

        public double Value => _value;

        public string ClientSector => _clientSector;

        public DateTime NextPaymentDate => _nextPaymentDate;

        public Trade(string tradeRecord)
        {
            var values = tradeRecord.Split(' ');
            _value = double.Parse(values[0]);
            _clientSector = values[1];
            _nextPaymentDate = DateTime.ParseExact(values[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
