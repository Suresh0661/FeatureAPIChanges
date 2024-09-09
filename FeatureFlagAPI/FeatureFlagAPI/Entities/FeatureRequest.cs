using System;

namespace FeatureFlagAPI.Entities
{
    public class FeatureRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string EstimatedComplexity { get; set; }
        public string Status { get; set; }
        public DateTime TargetCompletionDate { get; set; }
        public DateTime ActualCompletionDate { get; set; }
    }
}
