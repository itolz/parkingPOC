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

namespace ParkingPOCAPI.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentosController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estabelecimento>>> GetEstabelecimento()
        {
            return  Ok( await _estabelecimentoRepository.Listar());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Estabelecimento>> GetEstabelecimento(Guid id)
        {
            var estabelecimento = await _estabelecimentoRepository.Selecionar(id);

            if (estabelecimento == null)
            {
                return NotFound();
            }

            return Ok(estabelecimento);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstabelecimento(Guid id, Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id)
            {
                return BadRequest();
            }

            try
            {
                await _estabelecimentoRepository.Atualizar(id, estabelecimento);
            }
            catch
            {
                if (!_estabelecimentoRepository.EstabelecimentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Estabelecimento>> PostEstabelecimento(Estabelecimento estabelecimento)
        {
            await _estabelecimentoRepository.Incluir(estabelecimento);

            return CreatedAtAction("GetEstabelecimento", new { id = estabelecimento.Id }, estabelecimento);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estabelecimento>> DeleteEstabelecimento(Guid id)
        {

            var estabelecimentoTask = _estabelecimentoRepository.Selecionar(id);

            var estabelecimento = await estabelecimentoTask;


            if (estabelecimento == null)
            {
                return NotFound();
            }

            await _estabelecimentoRepository.Delete(estabelecimento);

            return estabelecimento;
        }

    }
}
