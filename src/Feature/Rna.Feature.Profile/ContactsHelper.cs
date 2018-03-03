using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rna.Foundation.XConnect;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;

namespace Rna.Feature.Profile
{
    public static class ContactsHelper
    {
        public static void AddContactAndProfileScore()
        {
            using (var client = Client.GetClient())
            {
                var identifiers = new ContactIdentifier[]
                {
                    new ContactIdentifier("domain", "hackathon20182.sc", ContactIdentifierType.Known)
                };
                var contact = new Contact(identifiers);

                var personalInfoFacet = new PersonalInformation
                {
                    FirstName = "Test",
                    LastName = "User"
                };
                client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, personalInfoFacet);

                var emailFacet = new EmailAddressList(new EmailAddress("developer1@hackathon2018.com", true), "hackathon");
                client.SetFacet<EmailAddressList>(contact, EmailAddressList.DefaultFacetKey, emailFacet);

                var profileScores = new ProfileScores();
                profileScores.Scores.Add(ProfileConstants.ProfileKeys.DeveloperKeyId, ProfileConstants.ProfileScores.DeveloperProfileScore);

                client.AddContact(contact);
                client.Submit();

                //direct channel guid {42B67B0E-70BA-4D6F-B9BC-41756A910358}
                var interaction = new Interaction(contact, InteractionInitiator.Contact, Guid.Parse("{42B67B0E-70BA-4D6F-B9BC-41756A910358}"), "Voice Transcript");

                client.SetProfileScores(interaction, profileScores);
                client.Submit();

            }
        }

        //private static async void SearchContacts()
        //{
        //    using (var client = Client.GetClient())
        //    {
        //        var queryable = client.Contacts
        //            .Where(c => c.Interactions.Any(x => x.StartDateTime > DateTime.UtcNow.AddDays(-30)))
        //            .WithExpandOptions(new ContactExpandOptions("Personal"));

        //        var results = await queryable.ToSearchResults();
        //        var contacts = await results.Results.Select(x => x.Item).ToList();
        //        foreach (var contact in contacts)
        //        {
        //            Console.WriteLine($"{contact.Personal().FirstName} {contact.Personal().LastName}");
        //        }
        //    }
        //}

        //private static void GetContact()
        //{
        //    using (var client = Client.GetClient())
        //    {
        //        var contactReference = new IdentifiedContactReference("twitter", "longhorntaco");
        //        var contact = client.Get(contactReference, new ExpandOptions() { FacetKeys = { "Personal" } });

        //        if (contact != null)
        //        {
        //            Console.WriteLine($"{contact.Personal().FirstName} {contact.Personal().LastName}");
        //        }
        //    }
        //}

        //private static void AddContact()
        //{
        //    using (var client = Client.GetClient())
        //    {
        //        var identifiers = new ContactIdentifier[]
        //        {
        //            new ContactIdentifier("twitter", "longhorntaco", ContactIdentifierType.Known),
        //            new ContactIdentifier("domain", "longhorn.taco", ContactIdentifierType.Known)
        //        };
        //        var contact = new Contact(identifiers);

        //        var personalInfoFacet = new PersonalInformation
        //        {
        //            FirstName = "Longhorn",
        //            LastName = "Taco"
        //        };
        //        client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, personalInfoFacet);

        //        var emailFacet = new EmailAddressList(new EmailAddress("longhorn@taco.com", true), "twitter");
        //        client.SetFacet<EmailAddressList>(contact, EmailAddressList.DefaultFacetKey, emailFacet);
        //        var behaviourProfile = new ContactBehaviorProfile
        //        {
        //            Scores = { new Guid(),new ProfileScore {} }
        //        };

        //        client.AddContact(contact);
        //        client.Submit();
        //    }
        //}



        //private static void AddInteraction()
        //{
        //    using (var client = Client.GetClient())
        //    {
        //        var contactReference = new IdentifiedContactReference("twitter", "longhorntaco");
        //        var contact = client.Get(contactReference, new ExpandOptions() { FacetKeys = { "Personal" } });

        //        if (contact != null)
        //        {
        //            // Item ID of the "Enter Store" Offline Channel at 
        //            // /sitecore/system/Marketing Control Panel/Taxonomies/Channel/Offline/Store/Enter store
        //            var enterStoreChannelId = Guid.Parse("{3FC61BB8-0D9F-48C7-9BBD-D739DCBBE032}");
        //            var userAgent = "xConnectIntro Console App";

        //            var interaction = new Interaction(contact, InteractionInitiator.Contact, enterStoreChannelId, userAgent);

        //            var productPurchaseOutcomeId = Guid.Parse("{9016E456-95CB-42E9-AD58-997D6D77AE83}");
        //            var outcome = new Outcome(productPurchaseOutcomeId, DateTime.UtcNow, "USD", 42.95m);

        //            interaction.Events.Add(outcome);

        //            client.AddInteraction(interaction);
        //            client.Submit();
        //        }
        //    }
        //}

    }
}
