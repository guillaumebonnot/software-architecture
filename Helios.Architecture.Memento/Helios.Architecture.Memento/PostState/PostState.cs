using System;
using System.Collections.Generic;

namespace Helios.Architecture.Memento.PostState
{
    // handles mutable accounts
    class PostState
    {
        private readonly State state;
        // accounts that have been modified
        private readonly Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        private readonly Action<IAccount> callback;

        public PostState(State state, Action<IAccount> callback)
        {
            this.state = state;
            this.callback = callback;
        }

        public bool TryGetAccount(string username, out Account account)
        {
            // find new version
            if (accounts.TryGetValue(username, out account))
            {
                return true;
            }
            
            // find old version
            if (state.TryGetAccount(username, out var old))
            {
                account = new Account(old.Name, old.Version + 1, old.GetBalances());
                SetAccount(username, account);
                return true;
            }

            return false;
        }

        public void SetAccount(string username, Account account)
        {
            accounts[username] = account;
            callback(account);
        }

        // apply the post state to update the underlying state
        public void Apply()
        {
            foreach (var account in accounts.Values)
            {
                Console.WriteLine($"Update Account {account.Name} Version {account.Version}");
                state.SetAccount(account.Name, account);
            }
        }
    }
}