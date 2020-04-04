using System;
using System.Collections.Generic;
using System.Linq;

namespace Helios.Architecture.Pipeline.Processors
{
    public static class Test
    {
        public static void Run()
        {
            // build
            var pipeline = new Pipeline<Order>();
            pipeline.RegisterOperation(new CreateOrderProcessor());
            pipeline.RegisterOperation(new PriceOrderProcessor());
            pipeline.RegisterOperation(new PaymentOrderProcessor(User.Users.ToDictionary(user => user.Id, user => user.InitialBalance)));
            pipeline.RegisterOperation(new DeliverOrderProcessor());

            var monitor = new Pipeline<Order>();
            monitor.RegisterOperation(pipeline);
            monitor.RegisterOperation(new Operation<Order>(order =>
            {
                var report = order.Status == OrderStatus.Delivered ? "Success" : "Fail";
                Console.WriteLine($"[IMPORTANT] Order {order.OrderId} Finished Processing : {report}");
                return true;
            }));

            // process
            foreach (var product in GetOrders()) monitor.Invoke(product);
        }

        private static IEnumerable<Order> GetOrders()
        {
            yield return new Order(User.Alice.Id, Product.Pineapple.Id, 1); // to expensive for alice :(
            yield return new Order(User.Alice.Id, Product.Apple.Id, 1); // ok
            yield return new Order(User.Bob.Id, Product.Orange.Id, 5); // yay oranges for christmas !
            yield return new Order(User.Charlie.Id, Product.Banana.Id, 5); // ok
            yield return new Order(User.Charlie.Id, Product.Pineapple.Id, 5); // ok
            yield return new Order(User.Charlie.Id, Product.Orange.Id, 5); // ok
        }
    }

    public class User
    {
        public readonly int Id;
        public readonly decimal InitialBalance;

        private static readonly List<User> users = new List<User>();

        public User(decimal balance)
        {
            Id = users.Count;
            users.Add(this);
            InitialBalance = balance;
        }

        public static readonly User Alice = new User(1);
        public static readonly User Bob = new User(10);
        public static readonly User Charlie = new User(100);

        public static IEnumerable<User> Users => users;
    }
}