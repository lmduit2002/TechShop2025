using back_end.Domain.Entities;
using back_end.Domain.Interfaces;
using back_end.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace back_end.Infrastructure.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly MyDbContext _context;
        public CategoryRepository(MyDbContext context) 
        { 
            _context = context;
        }

        async Task<Category> ICategoryRepository.Create(Category param)
        {
            var res = _context.Categories.Add(param);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        async Task ICategoryRepository.Delete(Category param)
        {
            _context.Categories.Remove(param);
            await _context.SaveChangesAsync();
        }

        async Task<List<Category>> ICategoryRepository.GetAll()
        {
            var res = await _context.Categories.Where(p => p.IsActive == true).ToListAsync();
            return res;
        }

        Task<Category> ICategoryRepository.Update(Category param)
        {
            var res = _context.Categories.Update(param);
            return Task.FromResult(res.Entity);
        }
    }
}
