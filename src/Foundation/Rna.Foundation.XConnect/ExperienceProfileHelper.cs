using System;
using Sitecore.XConnect;
using Sitecore.XConnect.Client;
using Sitecore.XConnect.Collection.Model;

namespace Rna.Foundation.XConnect
{
    public static class ExperienceProfileHelper
    {
        public static void AddContact(string contactIdentifier)
        {
            using (var client = Client.GetClient())
            {
                var identifiers = new ContactIdentifier[]
                {
                    new ContactIdentifier("VoiceApp", contactIdentifier, ContactIdentifierType.Known)
                };
                var contact = new Contact(identifiers);

                var personalInfoFacet = new PersonalInformation
                {
                    FirstName = "Test",
                    LastName = "User"
                };
                client.SetFacet<PersonalInformation>(contact, PersonalInformation.DefaultFacetKey, personalInfoFacet);

                //assuming contact identifier is an email value
                var emailFacet = new EmailAddressList(new EmailAddress(contactIdentifier, true), "hackathon");
                client.SetFacet<EmailAddressList>(contact, EmailAddressList.DefaultFacetKey, emailFacet);

                client.AddContact(contact);
                client.Submit();
            }
        }

        public static void AddProfileScore(string contactIdentifier, string occupation)
        {
            if (string.IsNullOrEmpty(contactIdentifier))
            {
                Console.WriteLine("Unable to find contact with empty identifier");
                return;
            }

            using (var client = Client.GetClient())
            {
                var contactReference = new IdentifiedContactReference("VoiceApp", contactIdentifier);
                var contact = client.Get(contactReference, new ExpandOptions() { FacetKeys = { "Personal" } });

                if (contact == null)
                {
                    Console.WriteLine("Unable to find contact with identifier:"+ contactIdentifier);
                }

                var profileScores = new ProfileScores();

                if(occupation.ToLower()==ProfileConstants.ProfileKeys.DeveloperKeyName)
                    profileScores.Scores.Add(ProfileConstants.ProfileKeys.DeveloperKeyId, ProfileConstants.ProfileScores.DeveloperProfileScore);
                else if (occupation.ToLower() == ProfileConstants.ProfileKeys.MarketerKeyName)
                    profileScores.Scores.Add(ProfileConstants.ProfileKeys.MarketerKeyId, ProfileConstants.ProfileScores.MarketerProfileScore);
                else
                    profileScores.Scores.Add(ProfileConstants.ProfileKeys.DeveloperKeyId, ProfileConstants.ProfileScores.OtherProfileScore);

                //online channel sitecore/system/Marketing Control Panel/Taxonomies/Channel/Online/Apps/Voice App
                var interaction = new Interaction(contact, InteractionInitiator.Contact, Guid.Parse("{BB2CBE9B-C9CD-4A75-8069-E4D72652399B}"), "Voice Transcript");
                // Voice Identification Outcome Guid
                // sitecore/system/Marketing Control Panel/Outcomes/Voice Identification
                var voiceIdentificationOutcomeId = Guid.Parse("{4CDA8824-94A3-45B8-BE0B-920497DBA3DA}");
                var outcome = new Outcome(voiceIdentificationOutcomeId, DateTime.UtcNow, "USD", 50);

                interaction.Events.Add(outcome);

                client.AddInteraction(interaction);

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
        //        return contacts.FirstOrDefault();
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
