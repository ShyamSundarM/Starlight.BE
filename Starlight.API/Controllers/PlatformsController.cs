using Microsoft.AspNetCore.Mvc;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;

namespace Starlight.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformsRepository _platformsRepository;
        public PlatformsController(IPlatformsRepository platformsRepository)
        {
            _platformsRepository = platformsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Platform>>> Get()
        {
            var platforms = await _platformsRepository.GetPlatformsAsync();
            return Ok(platforms);
        }

        public record CreatePlatformRequest(string Name);
        public record UpdatePlatformRequest(int id, string Name);

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreatePlatformRequest request)
        {
            var id = await _platformsRepository.InsertPlatform(request.Name.Trim());
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdatePlatformRequest request)
        {
            var rows = await _platformsRepository.UpdatePlatform(request.id, request.Name.Trim());
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rows = await _platformsRepository.DeletePlatform(id);
            return NoContent();
        }
    }
}
