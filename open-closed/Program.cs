using System;
using System.Collections.Generic;

namespace open_closed
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public class Product
    {
        public Product(string name, Color color, Size size)
        {
            this.name = name;
            this.Color = color;
            this.Size = size;
        }

        public string name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.Size == size)
                    yield return p;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            foreach (var product in pf.FilterBySize(products, Size.Large))
            {
                Console.WriteLine($"Large products (old): {product.name}");
            }            
        }
    }
}