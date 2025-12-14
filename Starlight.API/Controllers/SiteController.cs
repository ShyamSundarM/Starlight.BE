using Microsoft.AspNetCore.Mvc;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;

namespace Starlight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository siteRepository;
        public SiteController(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
        }

        [HttpGet("Config")]
        public async Task<IActionResult> GetConfig()
        {
            try
            {
                var items = await siteRepository.GetSiteConfigItemsAsync();
                return Ok(items);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("Config")]
        public async Task<IActionResult> AddConfig([FromBody] SiteConfigItem item)
        {
            if (item == null) return BadRequest();
            try
            {
                var id = await siteRepository.AddSiteConfigItemAsync(item);
                item.Id = id;
                return Created($"/api/Site/Config/{id}", item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Config")]
        public async Task<IActionResult> UpdateConfig([FromBody] SiteConfigItem item)
        {
            if (item == null) return BadRequest();
            try
            {
                await siteRepository.UpdateSiteConfigItemAsync(item);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("Config/{id:int}")]
        public async Task<IActionResult> DeleteConfig(int id)
        {
            try
            {
                await siteRepository.DeleteSiteConfigItemAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
