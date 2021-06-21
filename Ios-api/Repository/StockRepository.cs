using Ios_api.DBContext;
using Ios_api.DBContext.Entities;
using Ios_api.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Ios_api.Repository
{
    public class StockRepository : IStockRepository
    {
        private IosDBContext _context;

        public StockRepository(IosDBContext context)
        {
            _context = context;
        }

        public Stock GetStockByID(int id)
        {
            return _context.Stock.FirstOrDefault(i => i.id == id);
        }

        public List<Stock> GetStocks()
        {
            return _context.Stock.ToList();
        }

        public Stock AddStock(Stock stock)
        {
            _context.Add(stock);
            _context.SaveChanges();

            return stock;
        }

        public Stock UpdateStock(int id, Stock model)
        {
            var stock = GetStockByID(id);

            if (stock == null)
                return null;

            stock.productId = model.productId;
            stock.amount = model.amount;

            _context.Stock.Update(stock);
            _context.SaveChanges();

            return model;
        }

        public bool DeleteStock(int id)
        {
            var stock = GetStockByID(id);

            if (stock == null)
                return false;

            _context.Stock.Remove(stock);
            _context.SaveChanges();

            return true;
        }
    }
}
