using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.XConnect.Collection.Model;

namespace Rna.Feature.Profile
{
    public static class ProfileConstants
    {
        public static class ProfileScores
        {
            public static ProfileScore DeveloperProfileScore = new ProfileScore()
            {
                MatchedPatternId = PatternCards.TechnicalUserId, // Guid of matched profile
                ProfileDefinitionId = ProfileKeys.DeveloperKeyId, // Guid of profile
                Score = 100,
                ScoreCount = 1,
                Values = new Dictionary<Guid, double>() { { ProfileKeys.DeveloperKeyId, 100 } }
            };
            public static ProfileScore MarketerProfileScore = new ProfileScore()
            {
                MatchedPatternId = PatternCards.BusinessUserId, // Guid of matched profile
                ProfileDefinitionId = ProfileKeys.MarketerKeyId, // Guid of profile
                Score = 100,
                ScoreCount = 1,
                Values = new Dictionary<Guid, double>() { { ProfileKeys.MarketerKeyId, 100 } }
            };
        }
        
        public static class PatternCards
        {
            public static readonly Guid BusinessUserId = Guid.Parse("{E360EDB3-93D0-4774-9216-731F04133FF2}");
            public static readonly Guid TechnicalUserId = Guid.Parse("{C7220123-5280-453F-AC0A-E82D7BC54CC1}");
        }

        public static class ProfileKeys
        {
            public static readonly Guid DeveloperKeyId = Guid.Parse("{C958A3CD-437B-46B1-B5C5-67CBBFE121ED}");
            public static readonly Guid MarketerKeyId = Guid.Parse("{16819A69-F607-4080-8209-99FE37FC8840}");
        }
    }
}
