using AutoMapper.Configuration.Annotations;
using FirstApi.Application.DTOs;
using FirstApi.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecoMaiorQue : ControllerBase
    {
        private readonly IProductTeste _service;

        public PrecoMaiorQue(IProductTeste service)
        {
            _service = service;
        }

        [HttpGet("{PrecoMaiorQue:decimal}", Name = "PreçoMaiorQue")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> PreçoMaiorQue(decimal PrecoMaiorQue)
        {
            var prod = await _service.GetMaiorPrice(PrecoMaiorQue);
            return prod == null ? NotFound("Não tem preço maior.") : Ok(prod);
        }
    }
}
