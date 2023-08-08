
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductRepository _product;

        //public ProductController(IProductRepository product)
        //{
        //    _product = product;
        //}

        //[HttpGet]
        //public async Task<ActionResult<List<Product>>> GetProducts()
        //{
        //    var products = await _product.GetProductsAsync();
        //    return Ok(products);
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<List<Product>>> GetByIdProducts(int id)
        //{
        //    var product = await  _product.GetProductByIdAsync(id);
        //    return Ok(product);
        //}
    }
}
