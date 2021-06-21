using Ios_api.DBContext.Entities;
using System.Collections.Generic;

namespace Ios_api.Interface
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public Product AddProduct(Product productItem);
        public Product UpdateProduct(int id, Product productItem);
        public bool DeleteProduct(int id);
    }
}
