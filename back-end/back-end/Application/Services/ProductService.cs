using back_end.Application.DTOs;
using back_end.Application.Helpers;
using back_end.Application.Interfaces;
using back_end.Application.Models;
using back_end.Application.Validators;
using back_end.Domain.Entities;
using back_end.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Application.Services
{
    
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        public ProductService(IProductRepository product) 
        {
            _product = product;
        }

        public async Task<CommonResult<VwProduct>> Create(ProductModel param)
        {
            if (param == null) return CommonResult<VwProduct>.Fail("Sản phầm không tồn tại", 404);
            try
            {
                var product = new Product
                {
                    CategoryCode = param.CategoryCode,
                    ProductName = param.ProductName,
                    ProductNameEn = param.ProductNameEn,
                    Description = param.Description,
                    ProductVersion = 1,
                    BasePrice = param.BasePrice,
                };
                var res = await _product.Create(product);
                return CommonResult<VwProduct>.Success(res!);
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
            }
        }

        public Task<CommonResult<VwProduct>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResult<VwProduct>> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResult<List<VwProduct>>> GetProducts(ProductFilterDTO param)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResult<VwProduct>> Update(ProductModel param)
        {
            throw new NotImplementedException();
        }
    }
}
