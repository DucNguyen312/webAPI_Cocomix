using Cocomix_API.DTO;
using Cocomix_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cocomix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListProducts()
        {
            try
            {
                return Ok(await _productService.GetListProductReponses());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            try
            {
                var product = await _productService.GetProductReponse(id);
                if (product == null)
                {
                    return NotFound(); //không tìm thấy
                }
                return Ok(product);
            }
            catch
            {
                return BadRequest("Loi code");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            try
            {
                return Ok(await _productService.AddProduct(productDTO));
            }
            catch
            {
                return BadRequest("Loi code");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> udpateProduct(int id, ProductDTO productDTO)
        {
            try
            {
                return Ok(await _productService.UpdateProduct(id, productDTO));
            }
            catch
            {
                return BadRequest("Loi code");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                return Ok(await _productService.DeleteProduct(id));
            }
            catch
            {
                return BadRequest("Loi code");
            }
        }
    }
}
