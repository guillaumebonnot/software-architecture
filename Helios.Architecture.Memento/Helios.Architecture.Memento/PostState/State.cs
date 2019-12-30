using System.Collections.Generic;

namespace Helios.Architecture.Memento.PostState
{
    // handles immutable accounts
    internal class State
    {
        private readonly Dictionary<string, IAccount> accounts = new Dictionary<string, IAccount>();

        public bool TryGetAccount(string username, out IAccount account)
        {
            return accounts.TryGetValue(username, out account);
        }

        internal void SetAccount(string username, IAccount account)
        {
            accounts[username] = account;
        }
    }
}