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
    public class MovimientoInventariosController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public MovimientoInventariosController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/MovimientoInventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoInventario>>> GetMovimientoInventarios()
        {
            return await _context.MovimientoInventarios.ToListAsync();
        }

        // GET: api/MovimientoInventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoInventario>> GetMovimientoInventario(int id)
        {
            var movimientoInventario = await _context.MovimientoInventarios.FindAsync(id);

            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return movimientoInventario;
        }

        // PUT: api/MovimientoInventarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientoInventario(int id, MovimientoInventario movimientoInventario)
        {
            if (id != movimientoInventario.IdMovimientoInventario)
            {
                return BadRequest();
            }

            _context.Entry(movimientoInventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoInventarioExists(id))
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

        // POST: api/MovimientoInventarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovimientoInventario>> PostMovimientoInventario(MovimientoInventario movimientoInventario)
        {
            _context.MovimientoInventarios.Add(movimientoInventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimientoInventario", new { id = movimientoInventario.IdMovimientoInventario }, movimientoInventario);
        }

        // DELETE: api/MovimientoInventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimientoInventario(int id)
        {
            var movimientoInventario = await _context.MovimientoInventarios.FindAsync(id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            _context.MovimientoInventarios.Remove(movimientoInventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimientoInventarioExists(int id)
        {
            return _context.MovimientoInventarios.Any(e => e.IdMovimientoInventario == id);
        }
    }
}
