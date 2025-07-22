using back_end.Domain.Interfaces;

namespace back_end.Application.Validators
{
    public static class ProductValidator
    {
        public static bool CheckExistsProduct(IProductRepository repo,int id)
        {
            return repo.GetProductById(id) != null;
        }
    }
}
