using System;

namespace BranchingDemo.ImmutableObjects
{
    // **** Immutable class ****
    // Instance cannot change after it has been created.
    // Impossible to reproduce aliasing bug on an immutable object.

    // Entity Object requires mutation over its lifetime.
    // Value Object remains unchanged after instantiation.

    // Reason for sealed: this is now a value class, so if not sealed, MoneyAmountExt class would introduce the following:
    // MoneyAmountBase.Equals(MoneyAmountExt) returns true;
    // MoneyAmountExt.Equals(MoneyAmountBase) returns false; - it has extra fields it could check for equality that Base doesn't have
    sealed class MoneyAmount : IEquatable<MoneyAmount>
    {
        public decimal Amount { get; } // remove setter to make immutable
        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            if(amount < 0)
                throw new ArgumentException("message goes here");
            Amount = amount;
            CurrencySymbol = currencySymbol;
        }
        public MoneyAmount Scale(decimal factor) => new MoneyAmount(
            this.Amount * factor, this.CurrencySymbol);

        public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => amount.Scale(factor);

        public override bool Equals(object obj) => this.Equals(obj as MoneyAmount);

        public bool Equals(MoneyAmount other) => 
            other != null && 
            this.Amount == other.Amount && 
            this.CurrencySymbol == other.CurrencySymbol;

        public override int GetHashCode() => this.Amount.GetHashCode() ^ this.CurrencySymbol.GetHashCode();

        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) => !(a == b);

        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";
    }
}