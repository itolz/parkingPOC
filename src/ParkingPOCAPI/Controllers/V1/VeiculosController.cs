using Microsoft.AspNetCore.Mvc;
using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingPOCAPI.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;


        public VeiculosController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculo()
        {
            return Ok(await _veiculoService.Listar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(Guid id)
        {
            var veiculo = await _veiculoService.Selecionar(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(Guid id, Veiculo veiculo)
        {
            if (id != veiculo.Id) return BadRequest();

            var veiculoReturned = await _veiculoService.Atualizar(id, veiculo);

            if (veiculoReturned == null) return NotFound();

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
            await _veiculoService.Incluir(veiculo);

            return CreatedAtAction("GetVeiculo", new { id = veiculo.Id }, veiculo);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Veiculo>> DeleteVeiculo(Guid id)
        {
            var veiculo = await _veiculoService.Selecionar(id);

            if (veiculo == null) return NotFound();

            await _veiculoService.Delete(veiculo);

            return veiculo;
        }
    }
}
