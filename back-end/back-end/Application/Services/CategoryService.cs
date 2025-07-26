using back_end.Application.Helpers;
using back_end.Application.Interfaces;
using back_end.Application.Models;
using back_end.Domain.Entities;
using back_end.Domain.Interfaces;

namespace back_end.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _category;
        public CategoryService(ICategoryRepository category) 
        { 
            _category = category;
        }
        Task<CommonResult<Category>> ICategoryService.Create(CategoryModel param)
        {
            throw new NotImplementedException();
        }

        Task<CommonResult<Category>> ICategoryService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        async Task<CommonResult<List<Category>>> ICategoryService.GetAll()
        {
            var categories = await _category.GetAll();
            return CommonResult<List<Category>>.Success(categories);
        }

        Task<CommonResult<Category>> ICategoryService.Update(CategoryModel param)
        {
            throw new NotImplementedException();
        }
    }
}
