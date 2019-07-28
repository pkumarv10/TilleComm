using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TilleCommDAL;
using TilleCommModels;

namespace TilleCommAPI.Controllers
{
    public class ProductOrderController : ApiController
    {
        [Route("api/GetCartOrders")]
        [HttpPost]
        public IHttpActionResult GetCartOrders(SelectedOrder obj)
        {
            ProductOrderDataAccessLayer objProductDAL = new ProductOrderDataAccessLayer();

            return Ok(objProductDAL.GetSelectedProductDetails(obj));
        }
    }
}
