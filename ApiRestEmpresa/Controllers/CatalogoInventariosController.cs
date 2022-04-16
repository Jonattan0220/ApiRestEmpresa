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
    public class CatalogoInventariosController : ControllerBase
    {
        private readonly EmpresaContext _context;

        public CatalogoInventariosController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/CatalogoInventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoInventario>>> GetCatalogoInventarios()
        {
            return await _context.CatalogoInventarios.ToListAsync();
        }

        // GET: api/CatalogoInventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoInventario>> GetCatalogoInventario(int id)
        {
            var catalogoInventario = await _context.CatalogoInventarios.FindAsync(id);

            if (catalogoInventario == null)
            {
                return NotFound();
            }

            return catalogoInventario;
        }

        // PUT: api/CatalogoInventarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoInventario(int id, CatalogoInventario catalogoInventario)
        {
            if (id != catalogoInventario.IdCatalogoInventario)
            {
                return BadRequest();
            }

            _context.Entry(catalogoInventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoInventarioExists(id))
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

        // POST: api/CatalogoInventarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CatalogoInventario>> PostCatalogoInventario(CatalogoInventario catalogoInventario)
        {
            _context.CatalogoInventarios.Add(catalogoInventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogoInventario", new { id = catalogoInventario.IdCatalogoInventario }, catalogoInventario);
        }

        // DELETE: api/CatalogoInventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogoInventario(int id)
        {
            var catalogoInventario = await _context.CatalogoInventarios.FindAsync(id);
            if (catalogoInventario == null)
            {
                return NotFound();
            }

            _context.CatalogoInventarios.Remove(catalogoInventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatalogoInventarioExists(int id)
        {
            return _context.CatalogoInventarios.Any(e => e.IdCatalogoInventario == id);
        }
    }
}
