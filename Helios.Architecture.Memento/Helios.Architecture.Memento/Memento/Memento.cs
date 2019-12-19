using System;
using System.Collections.Generic;

namespace Helios.Architecture.Memento.Memento
{
    class Memento
    {
        private readonly Account account;
        private readonly Dictionary<string, int> balances;

        public Memento(Account account)
        {
            this.account = account;
            balances = account.GetBalances();
        }

        internal void Undo()
        {
            Console.WriteLine($"Restore {account.Name}.");
            account.Restore(balances);
        }
    }
}