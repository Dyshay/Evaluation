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
    public class OrderLineController : ApiController
    {
        [HttpGet]
        
        public IHttpActionResult FetchAll()
        {
            IEnumerable<LigneDeCommande> OrderLine = ServiceClientLocator.Instance.LigneDeCommand.Get();
            if (OrderLine.LongCount() == 0)
            {
                return NotFound();
            }
            return Json(OrderLine);  
        }
        [HttpPost]
        public IHttpActionResult Insert(LigneDeCommande Order)
        {
            LigneDeCommande Orderline = ServiceClientLocator.Instance.LigneDeCommand.Insert(Order);
            return Ok();
        }
    }
}
