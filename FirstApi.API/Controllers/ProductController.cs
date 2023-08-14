using FirstApi.Application.DTOs;
using FirstApi.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace FirstApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var prod = await _service.GetProducts();
            return prod == null ? NotFound("Products not found.") : Ok(prod);
        }

        [HttpGet("{id:int}", Name = "GetProduct")] // usado name no httpPost
        public async Task<ActionResult<ProductDTO>> GetById(int id)
        {
            var prod = await _service.GetById(id);
            return prod == null ? NotFound("Product not found") : Ok(prod);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            if (product == null) return BadRequest("Invalid Data.");

            await _service.Add(product);
            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id,[FromBody] ProductDTO product)
        {
            if (id != product.Id) return BadRequest("Invalid Id.");
            if (product == null) return BadRequest("Invalid data.");

            await _service.Update(product);

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var prod = await _service.GetById(id);

            if (prod == null) return NotFound("Product not found.");

            await _service.Delete(id);
            return Ok();
        }
    }
}
