using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;

namespace Starlight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : ControllerBase
    {
        private ISocialLinksRepository socialLinksRepository;

        public SocialLinksController(ISocialLinksRepository socialLinksRepository)
        {
            this.socialLinksRepository = socialLinksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSocialLinks()
        {
            try
            {
                var links = await socialLinksRepository.GetSocialLinksAsync();
                return Ok(links);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialLink([FromBody] SocialLink link)
        {
            if (link == null)
            {
                return BadRequest();
            }
            try
            {
                var id = await socialLinksRepository.AddSocialLinkAsync(link);
                link.Id = id;
                return Created($"/api/SocialLinks/{id}", link);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialLink([FromBody] SocialLink link)
        {
            if (link == null)
            {
                return BadRequest();
            }
            try
            {
                await socialLinksRepository.UpdateSocialLinkAsync(link);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSocialLink(int id)
        {
            try
            {
                var success = await socialLinksRepository.DeleteSocialLinkAsync(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
