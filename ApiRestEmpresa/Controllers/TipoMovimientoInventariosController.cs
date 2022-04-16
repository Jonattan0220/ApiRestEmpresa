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
    public class TipoMovimientoInventariosController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public TipoMovimientoInventariosController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/TipoMovimientoInventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMovimientoInventario>>> GetTipoMovimientoInventarios()
        {
            return await _context.TipoMovimientoInventarios.ToListAsync();
        }

        // GET: api/TipoMovimientoInventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMovimientoInventario>> GetTipoMovimientoInventario(int id)
        {
            var tipoMovimientoInventario = await _context.TipoMovimientoInventarios.FindAsync(id);

            if (tipoMovimientoInventario == null)
            {
                return NotFound();
            }

            return tipoMovimientoInventario;
        }

        // PUT: api/TipoMovimientoInventarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoMovimientoInventario(int id, TipoMovimientoInventario tipoMovimientoInventario)
        {
            if (id != tipoMovimientoInventario.IdTipoMovInventario)
            {
                return BadRequest();
            }

            _context.Entry(tipoMovimientoInventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoMovimientoInventarioExists(id))
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

        // POST: api/TipoMovimientoInventarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoMovimientoInventario>> PostTipoMovimientoInventario(TipoMovimientoInventario tipoMovimientoInventario)
        {
            _context.TipoMovimientoInventarios.Add(tipoMovimientoInventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoMovimientoInventario", new { id = tipoMovimientoInventario.IdTipoMovInventario }, tipoMovimientoInventario);
        }

        // DELETE: api/TipoMovimientoInventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoMovimientoInventario(int id)
        {
            var tipoMovimientoInventario = await _context.TipoMovimientoInventarios.FindAsync(id);
            if (tipoMovimientoInventario == null)
            {
                return NotFound();
            }

            _context.TipoMovimientoInventarios.Remove(tipoMovimientoInventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoMovimientoInventarioExists(int id)
        {
            return _context.TipoMovimientoInventarios.Any(e => e.IdTipoMovInventario == id);
        }
    }
}
