using back_end.Application.DTOs;
using back_end.Application.Helpers;
using back_end.Application.Models;
using back_end.Domain.Entities;

namespace back_end.Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<CommonResult<List<Category>>> GetAll();
        public Task<CommonResult<Category>> Create(CategoryModel param);
        public Task<CommonResult<Category>> Update(CategoryModel param);
        public Task<CommonResult<Category>> Delete(int id); 
    }
}
