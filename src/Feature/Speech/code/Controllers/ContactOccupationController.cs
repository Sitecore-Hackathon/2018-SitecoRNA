using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            // TODO: null-checking and error handling throughout this method
            // TODO: move logic out of controller and implement a CQRS pattern

            // get the file from the request
            var file = Request.Files["file"];
            if (file == null)
            {
                return new JsonResult()
                {
                    Data = new { Success = false, ErrorMessage = "File was null" }
                };
            }

            // get the service uri and subscription key
            var serviceUri = Sitecore.Configuration.Settings.GetSetting("Microsoft.API.Speech.ServiceUri");
            var subscriptionKey = Sitecore.Configuration.Settings.GetSetting("Microsoft.API.Speech.SubscriptionKey");

            var request = (HttpWebRequest)WebRequest.Create(serviceUri);
            request.SendChunked = true;
            request.Accept = @"application/json;text/xml";
            request.Method = "POST";
            request.ProtocolVersion = HttpVersion.Version11;
            request.ContentType = @"audio/wav; codec=audio/pcm; samplerate=16000";
            request.Headers["Ocp-Apim-Subscription-Key"] = subscriptionKey;
            
            using (var stream = file.InputStream)
            {
                using (var requestStream = request.GetRequestStream())
                {
                    /*
                    * Read 1024 raw bytes from the input audio file.
                    */
                    var buffer = new byte[checked((uint)Math.Min(1024, (int)stream.Length))];
                    var bytesRead = 0;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }

                    // Flush
                    requestStream.Flush();
                }
            }

            string responseString = null;
            using (var response = request.GetResponse())
            {
                var statusCode = ((HttpWebResponse) response).StatusCode;
                if (statusCode != HttpStatusCode.OK)
                {
                    return new JsonResult()
                    {
                        Data = new { Success = false, ErrorMessage = $"Service call to Microsoft Speech API failed. Response status: {statusCode}" }
                    };
                }

                var responseStream = response.GetResponseStream();
                if (responseStream == null)
                {
                    return new JsonResult()
                    {
                        Data = new { Success = false, ErrorMessage = $"Service call to Microsoft Speech API failed. Response stream was null" }
                    };
                }

                using (var sr = new StreamReader(responseStream))
                {
                    responseString = sr.ReadToEnd();
                }
            }

            if (string.IsNullOrEmpty(responseString))
            {
                return new JsonResult()
                {
                    Data = new { Success = false, ErrorMessage = $"Service call to Microsoft Speech API failed. Response string was null or empty" }
                };
            }
            // TODO: call Varun's stuff



            return new JsonResult()
            {
                Data = new { Success= true, Transcript = responseString }
            };
        }
    }
}