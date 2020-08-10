using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Data
{
    public class SqlDemoRepo : IProductsRepo
    {
        private readonly DemoContext _context;

        public SqlDemoRepo(DemoContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException();
            }

            _context.Products.Add(product);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateProduct(Product product)
        {
            //Nothing
        }
        
        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            _context.Products.Remove(product);
        }
    }
}
