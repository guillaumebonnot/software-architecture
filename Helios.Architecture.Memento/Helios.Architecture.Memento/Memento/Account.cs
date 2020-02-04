using System;
using System.Collections.Generic;
using Helios.Architecture.Memento.PostState;

namespace Helios.Architecture.Memento.Memento
{
    // mutable
    // not thread safe
    internal class Account : IAccount
    {
        public string Name { get; }
        private Dictionary<string, int> balances;

        // useless
        public int Version { get; }

        public Account(string name) : this(name, new Dictionary<string, int>()) { }

        public Account(string name, Dictionary<string, int> balances)
        {
            Name = name;
            this.balances = balances;
        }

        public int GetBalance(string currency)
        {
            if(balances.TryGetValue(currency, out var balance))
            {
                return balance;
            }
            return 0;
        }

        internal void SetBalance(string currency, int balance)
        {
            balances[currency] = balance;
            Console.WriteLine($"Account {Name} Balance {balance} {currency}.");
        }

        public Dictionary<string, int> GetBalances()
        {
            return new Dictionary<string, int>(balances);
        }

        internal void Restore(Dictionary<string, int> balances)
        {
            // not optimized but we want the balance to written in the console :)
            this.balances = new Dictionary<string, int>(balances.Count);
            foreach (var balance in balances)
            {
                SetBalance(balance.Key, balance.Value);
            }
        }
    }
}