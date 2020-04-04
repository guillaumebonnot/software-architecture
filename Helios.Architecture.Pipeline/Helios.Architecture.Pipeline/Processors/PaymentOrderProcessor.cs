using System;
using System.Collections.Generic;
using System.Linq;

namespace Helios.Architecture.Pipeline.Processors
{
    class PaymentOrderProcessor : Processor<Order>
    {
        private readonly Dictionary<int, decimal> balances;

        public PaymentOrderProcessor(Dictionary<int, decimal> balances)
        {
            this.balances = balances;
        }

        protected override bool Process(Order order)
        {
            var balance = GetBalance(order.UserId);
            var expected = balance - order.TotalPrice;

            if (expected >= 0)
            {
                Console.WriteLine($"Payment Order {order.OrderId} User {order.UserId} : {order.TotalPrice} USD | Balance {balance} -> {expected}");
                SetBalance(order.UserId, expected);
                order.Status = OrderStatus.Payed;
                return true;
            }
            else
            {
                Console.WriteLine($"Insufficient Balance : User {order.UserId} Balance {balance} USD | Order {order.OrderId} : {order.TotalPrice} USD");
                order.Status = OrderStatus.Canceled;
                return false;
            }
        }

        private decimal GetBalance(int user) => balances.TryGetValue(user, out var balance) ? balance : 0;
        private void SetBalance(int user, decimal balance) => balances[user] = balance;
    }
}