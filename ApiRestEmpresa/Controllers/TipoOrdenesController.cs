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
    public class TipoOrdenesController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public TipoOrdenesController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/TipoOrdenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoOrden>>> GetTipoOrdens()
        {
            return await _context.TipoOrdens.ToListAsync();
        }

        // GET: api/TipoOrdenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoOrden>> GetTipoOrden(int id)
        {
            var tipoOrden = await _context.TipoOrdens.FindAsync(id);

            if (tipoOrden == null)
            {
                return NotFound();
            }

            return tipoOrden;
        }

        // PUT: api/TipoOrdenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoOrden(int id, TipoOrden tipoOrden)
        {
            if (id != tipoOrden.IdTipoOrden)
            {
                return BadRequest();
            }

            _context.Entry(tipoOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoOrdenExists(id))
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

        // POST: api/TipoOrdenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoOrden>> PostTipoOrden(TipoOrden tipoOrden)
        {
            _context.TipoOrdens.Add(tipoOrden);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoOrden", new { id = tipoOrden.IdTipoOrden }, tipoOrden);
        }

        // DELETE: api/TipoOrdenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoOrden(int id)
        {
            var tipoOrden = await _context.TipoOrdens.FindAsync(id);
            if (tipoOrden == null)
            {
                return NotFound();
            }

            _context.TipoOrdens.Remove(tipoOrden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoOrdenExists(int id)
        {
            return _context.TipoOrdens.Any(e => e.IdTipoOrden == id);
        }
    }
}
