using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TilleComm.BusinessServvice.Interfaces;
using TilleComm.Helpers;
using TilleCommCommon;
using TilleCommModels;

namespace TilleComm.BusinessServvice.Concrete
{
    public class ProductsBusinessService : IProductsBusinessService
    {
        public async Task<List<Product>> GetProducts()
        {
            List<Product> result = new List<Product>();
            var httpClient = TilleCommHttpClient.GetClient();
            HttpResponseMessage response;
            //string jsonResult = JsonConvert.SerializeObject(user);
            response = await httpClient.GetAsync(TilleCommURL.GetProductsUrl);
            if (response.IsSuccessStatusCode)
            {
                var userAsstring = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<List<Product>>(userAsstring);
            }
            return result;
        }
        public async Task<Product> GetProductsbyId(int productId)
        {
            Product result = new Product();
            var httpClient = TilleCommHttpClient.GetClient();
            HttpResponseMessage response;

            response = await httpClient.GetAsync(string.Format(TilleCommURL.GetProductbyIdUrl, productId));
            if (response.IsSuccessStatusCode)
            {
                var userAsstring = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<Product>(userAsstring);
            }
            return result;
        }
        public async Task<SelectedOrder> GetSelectedProductOrderDetails(SelectedOrder objSelectedProducts)
        {
            SelectedOrder result = new SelectedOrder();
            var httpClient = TilleCommHttpClient.GetClient();
            HttpResponseMessage response;
            string jsonResult = JsonConvert.SerializeObject(objSelectedProducts);
            response = await httpClient.PostAsync(TilleCommURL.GetCartOrders, new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var userAsstring = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<SelectedOrder>(userAsstring);
            }
            return result;
        }
    }
}