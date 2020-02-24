using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
            //return _conn.GetAll<Product>();
        }
        
        public Product GetProductById(int id)
        {
            var products = _conn.Query<Product>("SELECT * FROM PRODUCTS;");

            return products.Where(p => p.ProductId == id).FirstOrDefault();
            //return _conn.Get<Product>(id);
        }
    }
}
