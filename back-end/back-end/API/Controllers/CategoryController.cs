using back_end.Application.Helpers;
using back_end.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        { 
            _categoryService = categoryService;
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _categoryService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(CommonResult<string>.Fail(ex.Message));
            }
        }
    }
}
