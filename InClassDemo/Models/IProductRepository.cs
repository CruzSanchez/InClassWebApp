using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClassDemo.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void CreateProduct(Product product);
    }
}
