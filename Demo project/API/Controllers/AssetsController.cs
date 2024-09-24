using Demo_project.Application.Services;
using Demo_project.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AssetService assetService;

        public AssetsController(AssetService assetService)
        {
            this.assetService = assetService;
        }

        [HttpGet]
        public IActionResult GetAllAssets()
        {
            IEnumerable<Asset> assets = assetService.GetAllAssets();
            return Ok(assets);
        }

        [HttpGet("{id}")]
        public IActionResult GetAssetById(string id)
        {
            Asset asset = assetService.GetAssetById(id);

            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }

        [HttpPost]
        public IActionResult AddAsset([FromBody] Asset asset)
        {
            assetService.AddAsset(asset);
            return Created(nameof(GetAssetById), new { id = asset.assetId });
        }

        [HttpPut("{id}")]
        public void UpdateAsset(string id, [FromBody] Asset asset)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteAsset(string id)
        {
            throw new NotImplementedException();
        }
    }
}
