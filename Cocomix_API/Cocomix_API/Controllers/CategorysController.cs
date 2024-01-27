using Cocomix_API.DTO;
using Cocomix_API.Models;
using Cocomix_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cocomix_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly CategoryService _categoryService;
       
        public CategorysController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                return Ok(await _categoryService.GetListCategory());
            }
            catch
            {
                return BadRequest("Loi code");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            try
            {
                var category = await _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> addCategory(CategoryDTO categoryDTO)
        {
            try
            {
                return Ok(await _categoryService.AddCategory(categoryDTO));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateCategory(int id, CategoryDTO categoryDTO)
        {
            try
            {
                var category = await _categoryService.UpdateCategory(id, categoryDTO);
                if (category == null) return NotFound();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCategory(int id)
        {
            try
            {
                var category = await _categoryService.DeleteCategory(id);
                if (category == null) return NotFound();
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("/{id}/products")]
        public async Task<IActionResult> getListProductByCategory(int id) 
        {
           
                return Ok(await _categoryService.getListProductByCategoryID(id));
           
            
        }

        [HttpPost("/{idCategory}/Product/{idProduct}")]
        public async Task<IActionResult> addProducttoCategory(int idCategory, int idProduct)
        {
            try
            {
                return Ok(await _categoryService.addProducttoCategory(idCategory, idProduct));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("/{idCategory}/Product/{idProduct}")]
        public async Task<IActionResult> deleteProducttoCategory(int idCategory, int idProduct)
        {
            try
            {
                var s = await _categoryService.deleteProductToCategory(idCategory, idProduct);
                return s != null ? Ok(s) : NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
