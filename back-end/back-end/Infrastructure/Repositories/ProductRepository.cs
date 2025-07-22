using back_end.Application.DTOs;
using back_end.Domain.Entities;
using back_end.Domain.Interfaces;
using back_end.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace back_end.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        async Task<VwProduct?> IProductRepository.Create(Product param)
        {
            var res = _context.Products.Add(param);
            await _context.SaveChangesAsync();
            return await CastToVwProduct(res.Entity.ProductId);
        }


        async Task IProductRepository.Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        async Task<VwProduct?> IProductRepository.GetProductById(int id)
        {
            return await _context.VwProducts.SingleOrDefaultAsync(e => e.ProductId == id);
        }

        IAsyncEnumerable<VwProduct?> IProductRepository.GetProducts(ProductFilterDTO param)
            => _context.VwProducts.Where(e => e.ProductName.ToLower().Contains(param.ProductName!.ToLower())
                                                   || e.ProductName.ToLower().Contains(param.ProductName!.ToLower())
                                                   || e.CategoryName!.ToLower().Contains(param.CategoryName!.ToLower())
                                                   || e.CategoryNameEn!.ToLower().Contains(param.CategoryNameEn!.ToLower())).AsAsyncEnumerable();

        async Task<VwProduct?> IProductRepository.Update(Product param)
        {
           var product = _context.Products.Update(param);
            await _context.SaveChangesAsync();
            return await CastToVwProduct(product.Entity.ProductId);
        }

        private async Task<VwProduct?> CastToVwProduct(int id)
        {
            return await _context.VwProducts.SingleOrDefaultAsync(e => e.ProductId == id);
        }
    }
}
