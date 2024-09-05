using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlagAPI.Repositories
{
    public class CreateFeatureRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string EstimatedComplexity { get; set; }
        public string Status { get; set; }
        public datetime TargetCompletionDate { get; set; }
        public datetime ActualCompletionDate { get; set; }
    }
}
