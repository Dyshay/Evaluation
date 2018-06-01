using Caisse_Televie.Model.Client.Entity;
using Caisse_Televie.Model.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_Caisse.Controllers
{
    public class ProduitController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FetchAll()
        {
            IEnumerable<Produit> Product = ServiceClientLocator.Instance.Produit.Get();
            if (Product.LongCount() == 0)
            {
                return NotFound();
            }
            return Json(Product);
        }
        [HttpGet]
        public IHttpActionResult FetchById(int ID)
        {
            Produit Product = ServiceClientLocator.Instance.Produit.Get(ID);
            if (Product == null)
            {
                return NotFound();
            }
            return Json(Product);
        }
    }
}
