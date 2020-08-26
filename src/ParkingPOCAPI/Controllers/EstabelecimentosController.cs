using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingPOC.Services.Models;
using ParkingPOCAPI.Data;

namespace ParkingPOCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly ParkingPOCAPIContext _context;

        public EstabelecimentosController(ParkingPOCAPIContext context)
        {
            _context = context;
        }

        // GET: api/Estabelecimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estabelecimento>>> GetEstabelecimento()
        {
            return await _context.Estabelecimento.ToListAsync();
        }

        // GET: api/Estabelecimentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estabelecimento>> GetEstabelecimento(Guid id)
        {
            var estabelecimento = await _context.Estabelecimento.FindAsync(id);

            if (estabelecimento == null)
            {
                return NotFound();
            }

            return estabelecimento;
        }

        // PUT: api/Estabelecimentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstabelecimento(Guid id, Estabelecimento estabelecimento)
        {
            if (id != estabelecimento.Id)
            {
                return BadRequest();
            }

            _context.Entry(estabelecimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstabelecimentoExists(id))
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

        // POST: api/Estabelecimentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Estabelecimento>> PostEstabelecimento(Estabelecimento estabelecimento)
        {
            _context.Estabelecimento.Add(estabelecimento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstabelecimento", new { id = estabelecimento.Id }, estabelecimento);
        }

        // DELETE: api/Estabelecimentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estabelecimento>> DeleteEstabelecimento(Guid id)
        {
            var estabelecimento = await _context.Estabelecimento.FindAsync(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            _context.Estabelecimento.Remove(estabelecimento);
            await _context.SaveChangesAsync();

            return estabelecimento;
        }

        private bool EstabelecimentoExists(Guid id)
        {
            return _context.Estabelecimento.Any(e => e.Id == id);
        }
    }
}
