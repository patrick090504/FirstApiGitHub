using FirstApi.Application.DTOs;
using FirstApi.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueMenorIgual : ControllerBase
    {
        private IProductTeste _service;

        public EstoqueMenorIgual(IProductTeste service)
        {
            _service = service;
        }

        [HttpGet("{StockMenorIgual:int}", Name = "StockMenorIgual")]

        public async Task<ActionResult<IEnumerable<ProductDTO>>> StockMenorIgual(int StockMenorIgual)
        {
            var prod = await _service.GetMenorIgualStock(StockMenorIgual);
            return prod == null ? NotFound("Não tem produto com estoque menor ou igual.") : Ok(prod);
        }
    }
}
