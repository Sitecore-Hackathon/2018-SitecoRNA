using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Rna.Feature.Speech.Controllers
{
    public class ContactOccupationController : Controller
    {
        /// <summary>
        /// Adds a new or updates the existing contact with the given email and occupation (discerned from the passed audio file)
        /// </summary>
        /// <param name="email">The email of the contact to be used as an identifier</param>
        /// <remarks>
        /// Expects an auto file named "file" to be included in the post
        /// </remarks>
        /// <returns>{ Success: true }, if successful</returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult AddOrUpdateContactOccupation([FromBody] string email)
        {
            // TODO: null-checking and error handling

            // get the file from the request
            var file = Request.Files["file"];

            // TODO: speech to text
            
            // TODO: call Varun's stuff

            return new JsonResult()
            {
                Data = new { Success= true}
            };
        }
    }
}