using Helios.Architecture.Memento.PostState;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace Helios.Architecture.Memento.Concurrency
{
    class SupervisorService
    {
        // thread safe queue
        private readonly BlockingCollection<IAccount> queue = new BlockingCollection<IAccount>(new ConcurrentQueue<IAccount>());

        // run this in a dedicated thread
        internal void Run()
        {
            while(true)
            {
                var account = queue.Take();
                CheckIntegrity(account);
            }
        }

        // check our invariant : the sum of balances is constant
        private void CheckIntegrity(IAccount account)
        {
            var total = account.GetBalances().Values.Sum(balance => balance);
            if (total != Program.INITIAL && total != 0)
            {
                var builder = new StringBuilder();
                foreach (var pair in account.GetBalances())
                {
                    builder.Append($" {pair.Value} {pair.Key}");
                }
                Console.WriteLine($"******* account state invalid : {account.Name} {builder} *********");
            }
        }

        // call this when account is updated
        internal void OnAccountUpdated(IAccount account)
        {
            // the account will be processed by the dedicated thread
            queue.Add(account);
        }
    }
}
