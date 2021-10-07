using System;

namespace TradeRisk.Interfaces
{
    interface ITrade
    {
        double Value { get; } //indicates the transaction amount in dollar
        string ClientSector { get; } //indicates the client's sector which can be "Public" or "Private"
        DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected
    }
}
