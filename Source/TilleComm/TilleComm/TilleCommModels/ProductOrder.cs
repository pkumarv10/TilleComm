using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilleCommModels
{
    public class ProductOrder
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool IsInCart { get; set; }
        public bool IsDelivered { get; set; }
    }
}
