using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Starlight.DataAccess.Interfaces;
using Starlight.DataAccess.Models;

namespace Starlight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
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
    }
}
