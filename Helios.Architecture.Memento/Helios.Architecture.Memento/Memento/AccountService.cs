using System;
using System.Collections.Generic;

namespace Helios.Architecture.Memento.Memento
{
    class AccountService : IAccountService
    {
        private readonly Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public void CreateAccount(string username)
        {
            if(accounts.ContainsKey(username))
            {
                Console.WriteLine($"Account {username} already exists !");
                return;
            }
            accounts.Add(username, new Account(username));
            Console.WriteLine($"Account {username} created.");
        }

        public void Deposit(string username, string currency, int amount)
        {
            if(!accounts.TryGetValue(username, out var account))
            {
                Console.WriteLine($"Account {username} does not exists !");
                return;
            }

            Console.WriteLine("Deposit");
            UpdateBalance(account, currency, amount);
        }

        private bool UpdateBalance(Account account, string currency, int delta)
        {
            var username = account.Name;
            var expected = account.GetBalance(currency) + delta;
            if(expected < 0)
            {
                Console.WriteLine($"Account {username} Balance cannot be negative : {expected} !");
                return false;
            }
            account.SetBalance(currency, expected);
            return true;
        }

        public void Exchange(string username1, string currency1, int amount1, string username2, string currency2, int amount2)
        {
            if (!accounts.TryGetValue(username1, out var account1))
            {
                Console.WriteLine($"Account {username1} does not exists !");
                return;
            }

            if (!accounts.TryGetValue(username2, out var account2))
            {
                Console.WriteLine($"Account {username2} does not exists !");
                return;
            }

            Console.WriteLine("Exchange");

            // we create a memento of account before we modify it
            var memento1 = new Memento(account1);
            var memento2 = new Memento(account2);

            // if error
            if (!(UpdateBalance(account1, currency1, -amount1)
                && UpdateBalance(account2, currency1, amount1)
                && UpdateBalance(account1, currency2, amount2)
                && UpdateBalance(account2, currency2, -amount2)))
            {
                // restore previous account state
                memento1.Undo();
                memento2.Undo();
            }
        }
    }
}
