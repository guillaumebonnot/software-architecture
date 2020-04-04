using System;

namespace Helios.Architecture.Pipeline.Processors
{
    class PriceOrderProcessor : Processor<Order>
    {
        protected override bool Process(Order order)
        {
            var price = GetPrice(order.ProductId);
            
            order.ProductPrice = price;
            order.TotalPrice = price * order.Quantity;
            order.Status = OrderStatus.Priced;

            Console.WriteLine($"Order {order.OrderId} Total Price {order.TotalPrice}");

            return true;
        }

        private decimal GetPrice(int product)
        {
            // this is simplified
            return Product.GetPrice(product);
        }
    }
}