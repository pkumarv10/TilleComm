using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilleCommModels;

namespace TilleComm.BusinessServvice.Interfaces
{
    public interface IProductsBusinessService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductsbyId(int productId);
        Task<SelectedOrder> GetSelectedProductOrderDetails(SelectedOrder productId);
    }
}
