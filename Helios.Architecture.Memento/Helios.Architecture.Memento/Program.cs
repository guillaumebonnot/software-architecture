using System;
using Helios.Architecture.Memento.Memento;

namespace Helios.Architecture.Memento
{
    class Program
    {
        private const string ALICE = "alice";
        private const string BOB = "bob";

        private const string BTC = "BTC";
        private const string USD = "USD";

        static void Main(string[] args)
        {
            var service = CreateAccountService();
            
            service.CreateAccount(ALICE);
            service.CreateAccount(BOB);

            service.Deposit(ALICE, BTC, 2);
            service.Deposit(BOB, USD, 9000);

            // ok
            service.Exchange(ALICE, BTC, 1, BOB, USD, 5000);
            // bob has not enough funds
            service.Exchange(ALICE, BTC, 1, BOB, USD, 5000);

            Console.ReadKey();
        }

        private static IAccountService CreateAccountService()
        {
            return new AccountService();
        }
    }
}
