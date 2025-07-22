using back_end.Application.Helpers;
using back_end.Application.Interfaces;
using back_end.Application.Models;
using back_end.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductModel product)
        {
            try
            {   
                var res = await _productService.Create(product);
                return Ok(res);
            } catch (Exception ex)
            {
                return BadRequest(CommonResult<string>.Fail(ex.Message));
            }
        }


    }
}
