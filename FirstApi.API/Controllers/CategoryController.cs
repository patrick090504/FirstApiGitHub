using FirstApi.Application.DTOs;
using FirstApi.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstApi.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var cat = await _service.GetCategories();
            return cat == null ? NotFound("Categories not found.") : Ok(cat);
        }

        /// <summary>
        /// Obter um usuário específico pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns></returns>
        /// <response code= "200">O usuário foi obtido com sucesso.</response>
        [HttpGet("{id:int}", Name = "GetCategory")] //Nomeado para httpPost
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var cat = await _service.GetById(id);
            return cat == null ? NotFound("Category not found.") : Ok(cat);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody]CategoryDTO category)
        {
            if (category == null) return BadRequest("Invalid Data");
            await _service.Create(category);

            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCategory(int id,[FromBody] CategoryDTO category)
        {
            if (id != category.Id) return BadRequest("Invalid Id.");
            if (category == null) return BadRequest("Invalid Data");
            await _service.Update(category);
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var cat = await _service.GetById(id);
            if (cat == null) return NotFound("Category not found");

            await _service.Delete(id);
            return Ok();
        }
    }
}
