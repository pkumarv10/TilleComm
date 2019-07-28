using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilleCommModels
{
    public class SelectedProduct
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product MyProductDetails { get; set; }
        public string CustomMessage { get; set; }
    }

    public class SelectedOrder
    {
        public int UserId { get; set; }
        public List<SelectedProduct> Products { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountedPrice { get; set; }
    }
}
