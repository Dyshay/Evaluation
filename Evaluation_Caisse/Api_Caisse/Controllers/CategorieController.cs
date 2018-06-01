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
    public class CategorieController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FetchAll()
        {
            IEnumerable<Categorie> Categorie = ServiceClientLocator.Instance.Categorie.Get();
            if (Categorie.LongCount() == 0)
            {
                return NotFound();
            }
            return Json(Categorie);
        }
        [HttpGet]
        public IHttpActionResult FetchById(int ID)
        {
            Categorie Categorie = ServiceClientLocator.Instance.Categorie.Get(ID);
            if (Categorie == null)
            {
                return NotFound();
            }
            return Json(Categorie);
        }
    }
}
