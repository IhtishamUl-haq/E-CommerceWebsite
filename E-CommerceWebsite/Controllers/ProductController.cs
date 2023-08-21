
using API.DTO;
using API.Errors;
using API.Helpers;
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
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
            [FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            var totalItems = await _product.CountAsync(countSpec);
            var products = await _product.GetListWithSpecAsync(spec);

            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,
                productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _product.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
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
