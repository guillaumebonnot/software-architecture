using System;
using System.Threading.Tasks;
using Helios.Architecture.Memento.Memento;
// using Helios.Architecture.Memento.PostState;

namespace Helios.Architecture.Memento.Concurrency
{
    class Program
    {
        private const string ALICE = "alice";
        private const string BOB = "bob";

        private const string BTC = "BTC";
        private const string USD = "USD";

        public const int INITIAL = 1000;

        static void Main(string[] args)
        {
            // create supervisor thread
            var supervisor = new SupervisorService();
            Task.Run(() =>
            {
                supervisor.Run();
            });

            var service = CreateAccountService();

            // register the supervisor callback
            service.AccountUpdated = supervisor.OnAccountUpdated;
            
            service.CreateAccount(ALICE);
            service.CreateAccount(BOB);

            service.Deposit(ALICE, BTC, INITIAL);
            service.Deposit(BOB, USD, INITIAL);

            // swap the balances
            for (int i = 0; i < INITIAL; i++)
            {
                service.Exchange(ALICE, BTC, 1, BOB, USD, 1);
            }

            Console.ReadKey();
        }

        private static IAccountService CreateAccountService()
        {
            return new AccountService();
        }
    }
}
