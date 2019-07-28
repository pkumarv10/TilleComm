using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilleCommModels;

namespace TilleCommDAL
{
    public class ProductDataAccessLayer
    {
        public List<Product> _lstProducts = new List<Product>();
        public ProductDataAccessLayer()
        {
            _lstProducts.Add(new Product { Id = 1, TypeId = 1, ProductName = "Small Pizza", Description = "10” pizza for one person", Price = 269.99, IsAvailable = true });
            _lstProducts.Add(new Product { Id = 2, TypeId = 1, ProductName = "Medium Pizza", Description = "12” pizza for two people", Price = 322.99, IsAvailable = true });
            _lstProducts.Add(new Product { Id = 3, TypeId = 1, ProductName = "Large Pizza", Description = "15” pizza for four people", Price = 394.99, IsAvailable = true });
        }

        public List<Product> GetProducts()
        {
            return _lstProducts;
        }
        public Product GetProductbyId(int productId)
        {
            return _lstProducts.FirstOrDefault(x => x.Id == productId);
        }

        public double GetProductPricebyId(int productId)
        {
            return _lstProducts.FirstOrDefault(x => x.Id == productId).Price;
        }

        public List<Product> GetProductbyIds(List<int> productIds)
        {
            List<Product> objResult = new List<Product>();
            List<Product> obj = GetProducts();
            foreach (var item in productIds)
            {
                objResult.Add(obj.FirstOrDefault(x => x.Id == item));
            }
            return objResult;
        }
    }
}
