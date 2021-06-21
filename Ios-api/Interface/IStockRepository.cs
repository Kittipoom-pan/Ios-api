using Ios_api.DBContext.Entities;
using System.Collections.Generic;

namespace Ios_api.Interface
{
    public interface IStockRepository
    {
        public List<Stock> GetStocks();
        //public List<Stock> GetStockByProductId(int productId);
        public Stock AddStock(Stock StockItem);
        public Stock UpdateStock(int id, Stock StockItem);
        public bool DeleteStock(int id);
    }
}
