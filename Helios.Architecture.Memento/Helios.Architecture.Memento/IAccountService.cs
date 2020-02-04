using System;
using Helios.Architecture.Memento.PostState;

namespace Helios.Architecture.Memento
{
    public interface IAccountService
    {
        void CreateAccount(string username);
        void Deposit(string username, string currency, int amount);
        void Exchange(string username1, string currency1, int amount1, string username2, string currency2, int amount2);
        // new event
        Action<IAccount> AccountUpdated { get; set; }
    }
}