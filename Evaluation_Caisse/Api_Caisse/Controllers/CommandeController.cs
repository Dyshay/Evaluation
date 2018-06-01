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
    public class CommandeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FetchAll()
        {
            IEnumerable<Commande> Command = ServiceClientLocator.Instance.Commande.Get();
            if(Command.LongCount() == 0)
            {
                return NotFound();
            }
            return Json(Command);
        }
    }
}
