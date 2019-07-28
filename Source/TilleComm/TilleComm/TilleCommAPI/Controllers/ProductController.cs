using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TilleCommDAL;

namespace TilleCommAPI.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/GetProducts")]
        public IHttpActionResult GetProducts()
        {
            ProductDataAccessLayer objProductDAL = new ProductDataAccessLayer();

            return Ok(objProductDAL.GetProducts());
        }


        [Route("api/GetProducts/{productId}")]
        public IHttpActionResult GetProductsbyId(int productId)
        {
            ProductDataAccessLayer objProductDAL = new ProductDataAccessLayer();
            return Ok(objProductDAL.GetProductbyId(productId));
        }
    }
}
