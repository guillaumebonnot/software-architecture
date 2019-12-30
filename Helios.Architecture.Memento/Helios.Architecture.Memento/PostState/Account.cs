using System.Collections.Generic;

namespace Helios.Architecture.Memento.PostState
{
    // immutable
    internal interface IAccount
    {
        string Name { get; }
        int Version { get; }
        int GetBalance(string currency);
        Dictionary<string, int> GetBalances();
    }

    // mutable
    class Account : IAccount
    {
        public string Name { get; }
        public int Version { get; }
        private readonly Dictionary<string, int> balances;

        public Account(string name) : this(name, 0, new Dictionary<string, int>()) { }

        public Account(string name, int version, Dictionary<string, int> balances)
        {
            Name = name;
            Version = version;
            this.balances = balances;
        }

        public int GetBalance(string currency)
        {
            if (balances.TryGetValue(currency, out var balance))
            {
                return balance;
            }
            return 0;
        }

        public void SetBalance(string currency, int balance)
        {
            balances[currency] = balance;
        }

        public Dictionary<string, int> GetBalances()
        {
            return new Dictionary<string, int>(balances);
        }
    }
}