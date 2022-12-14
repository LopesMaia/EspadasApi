using EspadasApi.Models;
using EspadasApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

//O controller será usado para exibir os endpoins especificos
namespace EspadasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspadasController : ControllerBase
    {
        private IEspadaService _espadaService;

        public EspadasController(IEspadaService espadaService)
        {
            _espadaService = espadaService;
        }


        [HttpGet] //Diz que a chamada vai ser do tipo get
        public async Task<ActionResult<IAsyncEnumerable<Espada>>> GetEspadas()
        {
            try
            {
                var espadas = await _espadaService.GetEspadas();
                return Ok(espadas);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

        [HttpGet("EspadaPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Espada>>> GetEspadasByName([FromQuery] string nome)
        {
            try
            {
                var espadas = await _espadaService.GetEspadasByName(nome);
                if (espadas == null)
                    return NotFound($"Nao existem espadas com o nome {nome}");

                return Ok(espadas);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

        [HttpGet("EspadaPorFamilia")]
        public async Task<ActionResult<IAsyncEnumerable<Espada>>> GetEspadasByFamilia([FromQuery] string familia)
        {
            try
            {
                var espadas = await _espadaService.GetEspadasByFamilia(familia);
                if (espadas == null)
                    return NotFound($"Nao existem espadas da familia {familia}");

                return Ok(espadas);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

        [HttpGet("{id:int}", Name = "GetEspada")]
        public async Task<ActionResult<Espada>> GetEspada(int id)
        {
            try
            {
                var espada = await _espadaService.GetEspada(id);
                if (espada == null)
                    return NotFound($"Não existem espadas com o id {id}");

                return Ok(espada);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Espada espada)
        {
            try
            {
                await _espadaService.CreateEspada(espada);
                return CreatedAtRoute(nameof(GetEspada), new { id = espada.Id }, espada);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Espada espada)
        {
            try
            {
                if (espada.Id == id)
                {
                    await _espadaService.UpdateEspada(espada);
                    return Ok("Espada atualizada");
                }
                else
                    return BadRequest("BadRequest");
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var espada = await _espadaService.GetEspada(id);
                if (espada != null)
                {
                    await _espadaService.DeleteEspada(espada);
                    return Ok("Espada deletada");
                }
                else
                    return NotFound("Espada não encontrada");
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }
    }
}
