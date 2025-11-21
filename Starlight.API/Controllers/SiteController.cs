using Microsoft.AspNetCore.Mvc;
using Starlight.DataAccess.Interfaces;

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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Starlight BE is running.");
        }

        [HttpGet]
        [Route("Config")]
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
    }
}
