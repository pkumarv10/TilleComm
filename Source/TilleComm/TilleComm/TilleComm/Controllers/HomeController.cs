using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TilleComm.BusinessServvice.Interfaces;
using TilleComm.Helpers;
using TilleComm.Models;
using TilleCommModels;

namespace TilleComm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public IProductsBusinessService _productService;
        public HomeController(IProductsBusinessService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index()
        {
            ProductsVM obj = new ProductsVM();
            obj.Products = await _productService.GetProducts();
            TempData["Products"] = obj;
            return View(obj);
        }
        public async Task<SelectedOrder> GetCartDetails(List<SelectedProduct> products)
        {
            SelectedOrder objSelectOrder = new SelectedOrder();
            
            objSelectOrder.UserId = SessionHelper.GetUserID();
            objSelectOrder.Products = products;
            objSelectOrder = await _productService.GetSelectedProductOrderDetails(objSelectOrder);
            return objSelectOrder;
        }
        public async Task<ActionResult> PlaceOrder()
        {
            SelectedProductVM objVM = new SelectedProductVM();
            List<SelectedProduct> products = new List<SelectedProduct>();
            List<int> productIds = (List<int>)TempData["SelectedProducts"];
            if (TempData["SelectedProducts"]!=null && productIds.Count() > 0)
            {
                foreach (var item in productIds)
                {
                    products.Add(new SelectedProduct { ProductId = item });
                }
                TempData["SelectedProducts"] = productIds;
                
                objVM.MyProduct = await GetCartDetails(products);
            }
            return View(objVM);
        }

        public async Task<PartialViewResult> GetCartDetailsView(List<SelectedProduct> products)
        {
            SelectedProductVM objVM = new SelectedProductVM();
            objVM.MyProduct = await GetCartDetails(products);

            return PartialView("~/Views/PartialView/_Cart.cshtml", objVM);
        }
        
        public int AddtoCart(string productId)
        {
            List<int> lstSelectedProducts = new List<int>();
            if (TempData["SelectedProducts"] != null)
            {
                lstSelectedProducts = (List<int>)TempData["SelectedProducts"];
                
            }
            lstSelectedProducts.Add(Convert.ToInt32(productId));
            TempData["SelectedProducts"] = lstSelectedProducts;
            return lstSelectedProducts.Count();
        }

        public int RemoveFromCart(string productId)
        {
            List<int> lstSelectedProducts = new List<int>();
            if (TempData["SelectedProducts"] != null)
            {
                lstSelectedProducts = (List<int>)TempData["SelectedProducts"];

            }
            lstSelectedProducts.Remove(Convert.ToInt32(productId));
            TempData["SelectedProducts"] = lstSelectedProducts;
            return lstSelectedProducts.Count();
        }
    }
}