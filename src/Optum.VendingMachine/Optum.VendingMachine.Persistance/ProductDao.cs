using Optum.VendingMachine.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optum.VendingMachine.Persistance
{
    public class ProductDao : IProductDao
    {
        private readonly List<Product> _products;

        public ProductDao()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Cola",
                    Price = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Chips",
                    Price = 0.50
                },
                new Product
                {
                    Id = 3,
                    Name = "Candy",
                    Price = 0.65
                }
            };
        }
        public IReadOnlyList<Product> GetProducts()
        {
            return _products;
        }
    }
}
