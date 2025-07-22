using back_end.Application.DTOs;
using back_end.Domain.Entities;

namespace back_end.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Task<VwProduct?> GetProductById(int id);
        public IAsyncEnumerable<VwProduct?> GetProducts(ProductFilterDTO param);
        public Task<VwProduct?> Create(Product param);
        public Task<VwProduct?> Update(Product param);
        public Task Delete(Product product);
    }
}
