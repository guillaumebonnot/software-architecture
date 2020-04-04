using System;

namespace Helios.Architecture.Pipeline.Processors
{
    class Order
    {
        // request
        public readonly int UserId;
        public readonly int ProductId;
        public readonly int Quantity;

        public OrderStatus Status = OrderStatus.New;

        // create order
        public int OrderId;
        public DateTime CreationTime;

        // price order
        public decimal ProductPrice;
        public decimal TotalPrice;

        // deliver order
        public DateTime DeliveryTime;

        public Order(int userId, int productId, int quantity)
        {
            UserId = userId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}