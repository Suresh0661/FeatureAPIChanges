using FeatureFlagAPI.Data;
using FeatureFlagAPI.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FeatureFlagAPI.Repositories
{
    public class FeatureService : IFeatureService
    {
        private readonly DbContextClass _dbContext;

        public FeatureService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FeatureRequest>> GetFeatureListAsync()
        {
            return await _dbContext.Feature
                .FromSqlRaw<FeatureRequest>("GetFeatureList")
                .ToListAsync();
        }       

        public async Task<int> AddFeatureAsync(FeatureRequest feature)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Title", feature.Title));
            parameter.Add(new SqlParameter("@Description", feature.Description));
            parameter.Add(new SqlParameter("@EstimatedComplexity", feature.EstimatedComplexity));
            parameter.Add(new SqlParameter("@Status", feature.Status));
            parameter.Add(new SqlParameter("@TargetCompletionDate", feature.TargetCompletionDate));
            parameter.Add(new SqlParameter("@ActualCompletionDate", feature.ActualCompletionDate));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewFeature @Title, @Description, @EstimatedComplexity, @Status, @TargetCompletionDate, @ActualCompletionDate", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateFeatureAsync(FeatureRequest feature)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Title", feature.Title));
            parameter.Add(new SqlParameter("@Description", feature.Description));
            parameter.Add(new SqlParameter("@EstimatedComplexity", feature.EstimatedComplexity));
            parameter.Add(new SqlParameter("@Status", feature.Status));
            parameter.Add(new SqlParameter("@TargetCompletionDate", feature.TargetCompletionDate));
            parameter.Add(new SqlParameter("@ActualCompletionDate", feature.ActualCompletionDate));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateFeature @Title, @Description, @EstimatedComplexity, @Status, @ProductStock, @TargetCompletionDate, @ActualCompletionDate", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteFeatureAsync(int FeatureId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteFeatureByID {FeatureId}"));
        }
    }
}
