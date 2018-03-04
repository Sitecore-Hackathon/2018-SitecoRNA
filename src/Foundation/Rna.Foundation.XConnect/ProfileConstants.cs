using System;
using System.Collections.Generic;
using Sitecore.XConnect.Collection.Model;

namespace Rna.Foundation.XConnect
{
    public static class ProfileConstants
    {
        public static class ProfileScores
        {
            //todo make dynamic
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
            public static ProfileScore OtherProfileScore = new ProfileScore()
            {
                MatchedPatternId = PatternCards.OtherUserId, // Guid of matched profile
                ProfileDefinitionId = ProfileKeys.OtherKeyId, // Guid of profile
                Score = 100,
                ScoreCount = 1,
                Values = new Dictionary<Guid, double>() { { ProfileKeys.OtherKeyId, 100 } }
            };
        }
        
        public static class PatternCards
        {
            //todo make dynamic
            public static readonly Guid BusinessUserId = Guid.Parse("{E360EDB3-93D0-4774-9216-731F04133FF2}");
            public static readonly Guid TechnicalUserId = Guid.Parse("{C7220123-5280-453F-AC0A-E82D7BC54CC1}");
            public static readonly Guid OtherUserId = Guid.Parse("{5ED22A3B-09DB-4650-A99F-A3E155416FF8}");

            public static readonly string BusinessUserPatterName = "businessuser";
            public static readonly string TechnicalUserPatternName = "technicaluser";
        }

        public static class ProfileKeys
        {
            //todo make dynamic
            public static readonly Guid DeveloperKeyId = Guid.Parse("{C958A3CD-437B-46B1-B5C5-67CBBFE121ED}");
            public static readonly Guid MarketerKeyId = Guid.Parse("{16819A69-F607-4080-8209-99FE37FC8840}");
            public static readonly Guid OtherKeyId = Guid.Parse("{1C0E404A-7B5A-41CC-A33B-A9E19A3A8B5B}");

            public static readonly string DeveloperKeyName = "developer";
            public static readonly string MarketerKeyName = "marketer";

        }
    }
}
