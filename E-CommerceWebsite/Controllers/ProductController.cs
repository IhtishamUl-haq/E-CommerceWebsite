
using API.DTO;
using AutoMapper;
using Core.Entites;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class ProductController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;

        public ProductController(IMapper mapper, IGenericRepository<Product> product,IGenericRepository<ProductBrand> productBrand ,IGenericRepository<ProductType>  productType )
        {
            _mapper = mapper;
            _product = product;
            _productBrand = productBrand;
            _productType = productType;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductReturnDto>>> GetProducts()
        {
            var specification = new ProductWithTypesAndBrandsSpecification();
            var product = await _product.GetListWithSpacAsync(specification);
             return _mapper.Map<List<ProductReturnDto>>(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProductReturnDto>>> GetByIdProducts(int id)
        {
            var specification = new ProductWithTypesAndBrandsSpecification(id);

            var products = await _product.GetListWithSpacAsync(specification);

            return _mapper.Map<List<ProductReturnDto>>(products);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductsBrands()
        {
            var productBrands = await _productBrand.AllListAsync();
            return Ok(productBrands);
        }

        [HttpGet("Types")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductsTypes()
        {
            var productTypes = await _productType.AllListAsync();
            return Ok(productTypes);
        }
    }
}
