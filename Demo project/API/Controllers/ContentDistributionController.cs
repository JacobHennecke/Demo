using Demo_project.Application.Services;
using Demo_project.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentDistributionsController : ControllerBase
    {
        private readonly ContentDistributionService contentDistributionService;

        public ContentDistributionsController(ContentDistributionService contentDistributionService)
        {
            this.contentDistributionService = contentDistributionService;
        }

        [HttpGet]
        public IActionResult GetAllContentDistributions()
        {
            ContentDistribution contentDistributions = contentDistributionService.GetAllContentDistributions();
            return Ok(contentDistributions);
        }

        [HttpGet("{id}")]
        public IActionResult GetContentDistributionById(string id)
        {
            ContentDistribution asset = contentDistributionService.GetContentDistributionById(id);

            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        [HttpPost]
        public IActionResult AddContentDistribution([FromBody] ContentDistribution contentDistribution)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void UpdateContentDistribution(string id, [FromBody] ContentDistribution contentDistribution)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteContentDistribution(string id)
        {
            throw new NotImplementedException();
        }
    }
}
