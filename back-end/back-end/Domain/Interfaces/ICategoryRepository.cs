using back_end.Domain.Entities;

namespace back_end.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll();
        public Task<Category> Create(Category param);
        public Task<Category> Update(Category param);
        public Task Delete(Category param);
    }
}
