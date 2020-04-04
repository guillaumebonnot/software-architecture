using System.Collections.Generic;

namespace Helios.Architecture.Pipeline.Processors
{
    public class Product
    {
        public readonly int Id;
        public readonly decimal Price;

        private static int count = 0;
        private static readonly List<Product> Products = new List<Product>();

        private Product(decimal price)
        {
            Id = count++;
            Price = price;
            Products.Add(this);
        }

        public static readonly Product Apple = new Product(0.83m);
        public static readonly Product Banana = new Product(0.74m);
        public static readonly Product Orange = new Product(0.45m);
        public static readonly Product Pineapple = new Product(1.43m);

        public static decimal GetPrice(int id) => Products[id].Price;
    }
}