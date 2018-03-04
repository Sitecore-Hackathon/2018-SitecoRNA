using Sitecore.Analytics;
using Sitecore.Diagnostics;
using Sitecore.Exceptions;
using System.Web.Mvc;

namespace Rna.Project.Hackathon.Controllers
{
    public class FormsController : Controller
    {
        [HttpPost]
        public void Submit(FormCollection formCollection)
        {
            var emailAddress = formCollection["txtEmailAddress"];
            var isActive = Tracker.Current != null && Tracker.Current.IsActive;

            if (!isActive)
                Tracker.Initialize();

            isActive = Tracker.Current != null && Tracker.Current.IsActive;

            if (!string.IsNullOrEmpty(emailAddress) && isActive)
            {
                try
                {
                    Tracker.Current.Session.IdentifyAs("VoiceApp", emailAddress); 
                }
                catch (ItemNotFoundException ex)
                {
                    //Error can happen if previous user profile has been deleted
                    Log.Error($"Could not identify the user '{emailAddress}'", ex, this);
                }
            }
        }
    }
}