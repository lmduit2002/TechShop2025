using back_end.Application.DTOs;
using back_end.Application.Helpers;
using back_end.Application.Models;
using back_end.Domain.Entities;

namespace back_end.Application.Interfaces
{
    public interface IProductService
    {
        // product
        public Task<CommonResult<VwProduct>> GetProductById(int id);
        public Task<CommonResult<List<VwProduct>>> GetProducts(ProductFilterDTO param);
        public Task<CommonResult<VwProduct>> Create(ProductModel param);
        public Task<CommonResult<VwProduct>> Update(ProductModel param);
        public Task<CommonResult<VwProduct>> Delete(int id);
        // product
    }
}
