using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace InClassDemo.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(Product product)
        {
            _conn.Insert(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            //return _conn.Query<Product>("SELECT * FROM PRODUCTS;"); Regular Dapper

            return _conn.GetAll<Product>(); // Dapper.Contrib
        }

        public Product GetProductById(int id)
        {
            //var products = _conn.Query<Product>("SELECT * FROM PRODUCTS;"); // Regular Dapper
            //return products.Where(p => p.ProductId == id).FirstOrDefault();

            return _conn.Get<Product>(id); // Dapper.Contrib
        }

        public void UpdateProduct(Product p)
        {
            _conn.Update(p);
        }
        
        public void DeleteProduct(Product p)
        {
            _conn.Delete(p);
        }        
    }
}
