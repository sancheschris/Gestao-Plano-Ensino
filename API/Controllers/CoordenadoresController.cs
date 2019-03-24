using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordenadoresController : ControllerBase
    {
        private readonly APIContext _context;

        public CoordenadoresController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Coordenadores
        [HttpGet]
        public IEnumerable<Coordenador> GetCoordenador()
        {
            return _context.Coordenador;
        }

        // GET: api/Coordenadores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoordenador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coordenador = await _context.Coordenador.FindAsync(id);

            if (coordenador == null)
            {
                return NotFound();
            }

            return Ok(coordenador);
        }

        // PUT: api/Coordenadores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordenador([FromRoute] int id, [FromBody] Coordenador coordenador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coordenador.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(coordenador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordenadorExists(id))
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

        // POST: api/Coordenadores
        [HttpPost]
        public async Task<IActionResult> PostCoordenador([FromBody] Coordenador coordenador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coordenador.Add(coordenador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoordenador", new { id = coordenador.UsuarioId }, coordenador);
        }

        // DELETE: api/Coordenadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoordenador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coordenador = await _context.Coordenador.FindAsync(id);
            if (coordenador == null)
            {
                return NotFound();
            }

            _context.Coordenador.Remove(coordenador);
            await _context.SaveChangesAsync();

            return Ok(coordenador);
        }

        private bool CoordenadorExists(int id)
        {
            return _context.Coordenador.Any(e => e.UsuarioId == id);
        }
    }
}