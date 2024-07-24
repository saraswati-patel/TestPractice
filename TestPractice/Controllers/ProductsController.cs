using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestPractice.Data;
using TestPractice.Data.Repositories;
using TestPractice.Models;
using TestPractice.Models.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BirlaDBContext _dbContext;
        private readonly IProduct _product;
        public ProductsController(BirlaDBContext dbContext, IProduct product)
        {
            _dbContext = dbContext;
            _product = product;
        }

        // GET: api/<ProductsController>
        [HttpGet("all-products")]
        [Authorize(Roles = "Admin,Customer,Seller")]
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok( await _product.GetAllProducts());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            return Ok(await _product.GetProductById(id));
        }

        // POST api/<ProductsController>
        [HttpPost("add-product")]
        [Authorize("Admin")]
        public async Task<ActionResult<Product>> AddProducts([FromBody] Productdto productdto)
        {
            await _product.AddProducts(new Product
            {
                Name = productdto.Name,
                Price = productdto.Price,
                Category = productdto.Category,
                Description = productdto.Description,
                Quantity = productdto.Quantity
            });
            return Created();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("update-product/{id}")]
        [Authorize("Seller,Admin")]
        public async Task<ActionResult> UpdateProductDetails(int id, [FromBody] Productdto productdto)
        {
            Product product = new Product
            {
                Name = productdto.Name,
                Price = productdto.Price,
                Quantity = productdto.Quantity,
                Category = productdto.Category,
                Description = productdto.Description
            };
            var result = await _product.UpdateProductDetails(id, product);
            return Ok(result);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("delete-product/{id}")]
        [Authorize("Admin")]
        public async Task<ActionResult> DeleteByProductId(int id)
        {
            _product.DeleteByProductId(id);
            return Ok();
        }
    }
}
