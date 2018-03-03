using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rna.Feature.Speech.Controllers
{
    public class ContactOccupationController : Controller
    {
        [HttpPost]
        public ActionResult AddOrUpdateContactOccupation()
        {
            var test = "hello";

            return new JsonResult()
            {
                Data = new { Success= true}
            };
        }
    }
}