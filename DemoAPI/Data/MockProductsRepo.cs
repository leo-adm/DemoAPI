using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Data
{
    public class MockProductsRepo : IProductsRepo
    {
        public Product GetProductById(int id)
        {
            return new Product { Id=0, Name = "Mock product name", Brand = "Mock product brand" };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = new List<Product>
            {
                new Product { Id=0, Name = "Mock product name 1", Brand = "Mock product brand 1" },
                new Product { Id=1, Name = "Mock product name 2", Brand = "Mock product brand 2" },
                new Product { Id=2, Name = "Mock product name 3", Brand = "Mock product brand 3" },
            };

            return products;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
