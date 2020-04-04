using System;
using System.Collections.Generic;

namespace Helios.Architecture.Pipeline.Processors
{
    class CreateOrderProcessor : Processor<Order>
    {
        private readonly List<Order> orders = new List<Order>();

        protected override bool Process(Order order)
        {
            order.OrderId = orders.Count;
            order.CreationTime = DateTime.UtcNow;
            order.Status = OrderStatus.Created;
            orders.Add(order);
            Console.WriteLine($"Create Order {order.OrderId}");
            return true;
        }
    }
}