using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TilleCommCommon;
using TilleCommModels;

namespace TilleCommDAL
{
    public class ProductOrderDataAccessLayer
    {
        ProductDataAccessLayer _productDataAccessLayer;
        UserDataAccessLayer _userDataAccessLayer;
        public ProductOrderDataAccessLayer()
        {
            _productDataAccessLayer = new ProductDataAccessLayer();
            _userDataAccessLayer = new UserDataAccessLayer();
        }
        #region PRIVATE
        private double GetDiscountedPrice(int userId, List<CalculateTotal> products)
        {
            double total = 0;
            if (userId == 0)
            {
               
                foreach (var item in products)
                {
                    total = total + item.Product.Price * item.Quantity;
                }
            }
            else
            {
                UserLogin objLogin = _userDataAccessLayer.GetUserById(userId);
                
                if (objLogin.OrgCode.ToUpper() == Convert.ToString(CommonEnum.Company.Infosys).ToUpper())
                {
                    #region INFOSYS
                    int smallPizzaCount = 0;
                    double smallPizzaPrice = 0;
                    double discount = 0;
                    foreach (var item in products)
                    {
                        total = total + item.Product.Price * item.Quantity;
                        if (item.Product.Id == 1)
                        {
                            smallPizzaPrice = item.Product.Price;
                            //Get Small
                            smallPizzaCount = item.Quantity;
                        }
                    }
                    
                    if (smallPizzaCount > 2)
                    {
                        double d = smallPizzaCount / 3;
                        discount = Math.Floor(d) * smallPizzaPrice;
                        total = total - discount;
                    }
                    #endregion
                }

                else if (objLogin.OrgCode.ToUpper() == Convert.ToString(CommonEnum.Company.Amazon).ToUpper())
                {
                    #region AMAZON
                    int largePizzaCount = 0;
                    double largePizzaPrice = 0;
                    double discount = 0;

                    foreach (var item in products)
                    {
                        total = total + item.Product.Price * item.Quantity;
                        if (item.Product.Id == 3)
                        {
                            largePizzaPrice = item.Product.Price;
                            //Get Small
                            largePizzaCount = item.Quantity;
                        }
                    }
                    if (largePizzaCount > 0)
                    {
                        discount = largePizzaCount * (largePizzaPrice - 299.99);
                        total = total - discount;
                    }

                    #endregion
                }

                else if (objLogin.OrgCode.ToUpper() == Convert.ToString(CommonEnum.Company.Facebook).ToUpper())
                {
                    #region FACEBOOK
                    int mediumPizzaCount = 0;
                    int largePizzaCount = 0;
                    double largePizzaPrice = 0;
                    double mediumPizzaPrice = 0;
                    double discount = 0;
                    foreach (var item in products)
                    {
                        total = total + item.Product.Price * item.Quantity;
                        if (item.Product.Id == 2)
                        {
                            mediumPizzaPrice = item.Product.Price;
                            //Get Medium
                            mediumPizzaCount = item.Quantity;
                        }
                        if (item.Product.Id == 3)
                        {
                            largePizzaPrice = item.Product.Price;
                            //Get Large
                            largePizzaCount = item.Quantity;
                        }
                    }

                    if (mediumPizzaCount > 4)
                    {
                        double d = mediumPizzaCount / 5;
                        discount = Math.Floor(d) * mediumPizzaPrice;
                        total = total - discount;
                    }
                    if (largePizzaCount > 0)
                    {
                        discount = largePizzaCount * (largePizzaPrice - 389.99);
                        total = total - discount;
                    }

                    #endregion
                }

            }
            return total;
        }
        private double GetTotalPrice(int userId, List<CalculateTotal> products)
        {
            double total = 0;
            foreach (var item in products)
            {
                total = total + item.Product.Price * item.Quantity;
            }
            return total;
        }

        #endregion
        private string GetCustomMessage(int userId)
        {
            if (userId == 0)
            {
                return "Custom mEssgae";
            }
            return "";
        }
        public class CalculateTotal
        {
            public int Quantity { get; set; }
            public Product Product { get; set; }
        }
        public SelectedOrder GetSelectedProductDetails(SelectedOrder obj)
        {
            List<CalculateTotal> lstProducts = new List<CalculateTotal>();
            if (obj != null)
            {
                if (obj.Products != null && obj.Products.Count() > 0)
                {
                    foreach (var item in obj.Products)
                    {
                        Product product = _productDataAccessLayer.GetProductbyId(item.ProductId);
                        item.MyProductDetails = product;
                        item.Quantity = (item.Quantity == 0 ? 1 : item.Quantity);
                        lstProducts.Add(new CalculateTotal { Quantity = item.Quantity, Product = product });
                        item.CustomMessage = GetCustomMessage(obj.UserId);
                    }
                    obj.DiscountedPrice = GetDiscountedPrice(obj.UserId, lstProducts);
                    obj.TotalPrice = GetTotalPrice(obj.UserId, lstProducts);
                }
            }
            return obj;
        }
    }
}
