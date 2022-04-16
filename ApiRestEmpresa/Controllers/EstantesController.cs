#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiRestEmpresa.Models;

namespace ApiRestEmpresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstantesController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public EstantesController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/Estantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estante>>> GetEstantes()
        {
            return await _context.Estantes.ToListAsync();
        }

        // GET: api/Estantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estante>> GetEstante(int id)
        {
            var estante = await _context.Estantes.FindAsync(id);

            if (estante == null)
            {
                return NotFound();
            }

            return estante;
        }

        // PUT: api/Estantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstante(int id, Estante estante)
        {
            if (id != estante.IdEstante)
            {
                return BadRequest();
            }

            _context.Entry(estante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstanteExists(id))
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

        // POST: api/Estantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estante>> PostEstante(Estante estante)
        {
            _context.Estantes.Add(estante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstante", new { id = estante.IdEstante }, estante);
        }

        // DELETE: api/Estantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstante(int id)
        {
            var estante = await _context.Estantes.FindAsync(id);
            if (estante == null)
            {
                return NotFound();
            }

            _context.Estantes.Remove(estante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstanteExists(int id)
        {
            return _context.Estantes.Any(e => e.IdEstante == id);
        }
    }
}
