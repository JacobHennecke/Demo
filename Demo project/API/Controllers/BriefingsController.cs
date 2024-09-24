using Demo_project.Application.Services;
using Demo_project.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BriefingsController : ControllerBase
    {
        private readonly BriefingService briefingsService;

        public BriefingsController(BriefingService briefingsService)
        {
            this.briefingsService = briefingsService;
        }

        [HttpGet]
        public IActionResult GetAllBriefings()
        {
            IEnumerable<Briefing> briefings = briefingsService.GetAllBriefings();
            return Ok(briefings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBriefingById(string id)
        {
            Briefing briefing = briefingsService.GetBriefingById(id);

            if (briefing == null)
            {
                return NotFound();
            }
            return Ok(briefing);
        }

        [HttpPost]
        public IActionResult AddBriefing([FromBody] Briefing briefing)
        {
            briefingsService.AddBriefing(briefing);
            return Created(nameof(GetBriefingById), new { id = briefing.assetId });
        }

        [HttpPut("{id}")]
        public void UpdateBriefing(string id, [FromBody] Briefing briefing)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteBriefing(string id)
        {
            throw new NotImplementedException();
        }
    }
}
