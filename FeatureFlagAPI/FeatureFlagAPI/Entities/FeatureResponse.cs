using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlagAPI.Repositories
{
    public class CreateFeatureResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
