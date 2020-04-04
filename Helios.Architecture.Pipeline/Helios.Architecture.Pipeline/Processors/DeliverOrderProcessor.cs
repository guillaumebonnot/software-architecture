using System;

namespace Helios.Architecture.Pipeline.Processors
{
    class DeliverOrderProcessor : Processor<Order>
    {
        protected override bool Process(Order order)
        {
            order.DeliveryTime = DateTime.UtcNow;
            order.Status = OrderStatus.Delivered;
            Console.WriteLine($"Order {order.OrderId} Delivered : {order.DeliveryTime}");
            return true;
        }
    }
}