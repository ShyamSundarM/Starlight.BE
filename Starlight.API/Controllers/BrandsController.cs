using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;

namespace Starlight.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsRepository _brandsRepository;
        public BrandsController(IBrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Brand>>> Get()
        {
            var brands = await _brandsRepository.GetBrandsAsync();
            return Ok(brands);
        }

        public record CreateBrandRequest(string Name);
        public record UpdateBrandRequest(int id, string Name, bool active);

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateBrandRequest request)
        {
            var id = await _brandsRepository.InsertBrand(request.Name.Trim());
            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateBrandRequest request)
        {
            var rows = await _brandsRepository.UpdateBrand(request.id, request.Name.Trim(), request.active);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rows = await _brandsRepository.DeleteBrand(id);
            return NoContent();
        }
    }
}
