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
    public class PrecoMenorIgual : ControllerBase
    {
        private readonly IProductTeste _service;

        public PrecoMenorIgual(IProductTeste service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> PreçoMenorIgual(decimal PreçoMenorIgual)
        {
            var prod = await _service.GetMenorIgualPrice(PreçoMenorIgual);
            return prod == null ? NotFound("Não tem preço menor ou igual.") : Ok(prod);
        }
    }
}
