using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;

namespace Starlight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IConfiguration _configuration;
        public ProductsController(IProductsRepository productsRepository, IConfiguration configuration)
        {
            _productsRepository = productsRepository;
            _configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetFullProducts()
        {
            try
            {
                var data = await _productsRepository.GetAllProductsAsync();
                foreach (var product in data)
                {
                    product.Links = await _productsRepository.GetProductLinks(product.ProductId);
                }

                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            try
            {
                if(product.Links != null && !product.Links.Any(l => l.PlatformId==1))
                {
                    return BadRequest("Primary image cannot be null");
                }
                
                var productId = await _productsRepository.InsertProduct(product);

                if (product.Links != null && product.Links.Count > 0)
                {
                    var links = product.Links;
                    foreach (var link in links)
                    {
                        link.ProductId = productId;
                    }
                    await _productsRepository.InsertProductLinks(links);

                }
                return CreatedAtAction(nameof(PostProduct), new { productId }, productId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct([FromBody] Product product)
        {
            try
            {
                if (product.Links != null && !product.Links.Any(l => l.PlatformId == 1))
                {
                    return BadRequest("Primary image cannot be null");
                }

                await _productsRepository.UpdateProduct(product);
                if (product.Links != null && product.Links.Count > 0)
                {
                    await _productsRepository.DeleteProductLinks(product.ProductId);
                    var links = product.Links;
                    foreach (var link in links)
                    {
                        link.ProductId = product.ProductId;
                    }
                    await _productsRepository.InsertProductLinks(links);
                }
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productsRepository.DeleteProductLinks(id);
                await _productsRepository.DeleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded");

            var account = new Account(_configuration["Cloudinary:CloudName"], _configuration["Cloudinary:APIKey"], _configuration["Cloudinary:APISecret"]);
            var cloudinary = new Cloudinary(account);

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Quality("auto").FetchFormat("auto").Crop("limit"),
                Folder = "starlight_products"
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            if (uploadResult.Error != null)
            {
                return BadRequest(uploadResult.Error.Message);
            }
            else
            {
                return Ok(uploadResult.SecureUrl);
            }
        }

    }
}
