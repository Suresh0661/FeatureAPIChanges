using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlagAPI.Repositories
{
    public interface IFeatureService
    {
        public Task<List<FeatureRequest>> GetFeatureListAsync();
        public Task<int> AddFeatureAsync(FeatureRequest feature);
        public Task<int> UpdateFeatureAsync(FeatureRequest feature);
        public Task<int> DeleteFeatureAsync(int Id);
    }
}
