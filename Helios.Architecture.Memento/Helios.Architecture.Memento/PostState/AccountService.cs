using System;

namespace Helios.Architecture.Memento.PostState
{
    public class AccountService : IAccountService
    {
        private readonly State state = new State();

        public void CreateAccount(string username)
        {
            TryUpdateState(poststate =>
            {
                if (poststate.TryGetAccount(username, out var account))
                {
                    Console.WriteLine($"Account {username} already exists !");
                    return false;
                }
                poststate.SetAccount(username, new Account(username));
                Console.WriteLine($"Account {username} created.");
                return true;
            });
        }

        public void Deposit(string username, string currency, int amount)
        {
            TryUpdateState(poststate =>
            {
                if (!poststate.TryGetAccount(username, out var account))
                {
                    Console.WriteLine($"Account {username} does not exists !");
                    return false;
                }

                Console.WriteLine("Deposit");
                return UpdateBalance(account, currency, amount);
            });
        }

        private bool UpdateBalance(Account account, string currency, int delta)
        {
            var username = account.Name;
            var expected = account.GetBalance(currency) + delta;
            if (expected < 0)
            {
                Console.WriteLine($"Account {username} Balance cannot be negative : {expected} !");
                return false;
            }
            account.SetBalance(currency, expected);
            return true;
        }

        public void Exchange(string username1, string currency1, int amount1, string username2, string currency2, int amount2)
        {
            TryUpdateState(poststate =>
            {
                if (!poststate.TryGetAccount(username1, out var account1))
                {
                    Console.WriteLine($"Account {username1} does not exists !");
                    return false;
                }

                if (!poststate.TryGetAccount(username2, out var account2))
                {
                    Console.WriteLine($"Account {username2} does not exists !");
                    return false;
                }

                Console.WriteLine("Exchange");

                return UpdateBalance(account1, currency1, -amount1)
                       && UpdateBalance(account2, currency1, amount1)
                       && UpdateBalance(account1, currency2, amount2)
                       && UpdateBalance(account2, currency2, -amount2);
            });
        }

        public Action<IAccount> AccountUpdated { get; set; }

        private void TryUpdateState(Func<PostState, bool> process)
        {
            // create post state
            var poststate = new PostState(state, AccountUpdated);
            // if success
            if (process(poststate))
            {
                poststate.Apply();
            }
            else
            {
                Console.WriteLine("Dropping Post State...");
            }
        }
    }
}
