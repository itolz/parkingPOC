using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using ParkingPOCAPI.Data;
using Services.Interfaces;

namespace ParkingPOCAPI.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentosController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estabelecimento>>> GetEstabelecimento()
        {
            return Ok(await _estabelecimentoService.Listar());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Estabelecimento>> GetEstabelecimento(Guid id)
        {
            var estabelecimento = await _estabelecimentoService.Selecionar(id);

            if (estabelecimento == null)
            {
                return NotFound();
            }

            return Ok(estabelecimento);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstabelecimento(Guid id, Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id) return BadRequest();
           
            var estabelecimentoReturned = await _estabelecimentoService.Atualizar(id, estabelecimento);

            if (estabelecimentoReturned == null) return NotFound();

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Estabelecimento>> PostEstabelecimento(Estabelecimento estabelecimento)
        {
            await _estabelecimentoService.Incluir(estabelecimento);

            return CreatedAtAction("GetEstabelecimento", new { id = estabelecimento.Id }, estabelecimento);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Estabelecimento>> DeleteEstabelecimento(Guid id)
        {
            var estabelecimento = await _estabelecimentoService.Selecionar(id);

            if (estabelecimento == null) return NotFound();
          
            await _estabelecimentoService.Delete(estabelecimento);

            return estabelecimento;
        }

    }
}
