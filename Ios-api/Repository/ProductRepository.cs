using Ios_api.DBContext;
using Ios_api.DBContext.Entities;
using Ios_api.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Ios_api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IosDBContext _context;

        public ProductRepository(IosDBContext context)
        {
            _context = context;
        }

        public Product GetProductByID(int id)
        {
            return _context.Product.FirstOrDefault(i => i.id == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Product.ToList();
        }

        public Product AddProduct(Product productItem)
        {
            _context.Add(productItem);
            _context.SaveChanges();

            return productItem;
        }

        public Product UpdateProduct(int id, Product model)
        {
            var product = GetProductByID(id);

            if (product == null)
                 return null;

            product.name = model.name;
            product.imageUrl = model.imageUrl;
            product.price = model.price;

            _context.Product.Update(product);
            _context.SaveChanges();

            return model;
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductByID(id);

            if (product == null)
                return false;

            _context.Product.Remove(product);
            _context.SaveChanges();

            return true;
        }
    }
}
