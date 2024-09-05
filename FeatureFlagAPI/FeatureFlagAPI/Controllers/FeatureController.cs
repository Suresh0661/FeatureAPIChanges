using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService featureService;

        public FeatureController(IFeatureService featureService)
        {
            this.featureService = featureService;
        }

        [HttpGet("getfeaturelist")]
        public async Task<List<FeatureRequest>> GetFeatureListAsync()
        {
            try
            {
                return await featureService.GetFeatureListAsync();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addfeature")]
        public async Task<IActionResult> AddFeatureAsync(FeatureRequest feature)
        {
            if (feature == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await featureService.AddFeatureAsync(feature);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatefeature")]
        public async Task<IActionResult> UpdateFeatureAsync(FeatureRequest feature)
        {
            if (feature == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await featureService.UpdateFeatureAsync(feature);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deletefeature")]
        public async Task<int> DeleteFeatureAsync(int Id)
        {
            try
            {
                var response = await featureService.DeleteFeatureAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
