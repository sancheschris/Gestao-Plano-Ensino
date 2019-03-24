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
    public class AdministradoresController : ControllerBase
    {
        private readonly APIContext _context;

        public AdministradoresController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Administradores
        [HttpGet]
        public IEnumerable<Administrador> GetAdministrador()
        {
            return _context.Administrador;
        }

        // GET: api/Administradores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdministrador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var administrador = await _context.Administrador.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }

        // PUT: api/Administradores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador([FromRoute] int id, [FromBody] Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrador.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administradores
        [HttpPost]
        public async Task<IActionResult> PostAdministrador([FromBody] Administrador administrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Administrador.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = administrador.UsuarioId }, administrador);
        }

        // DELETE: api/Administradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administrador.Remove(administrador);
            await _context.SaveChangesAsync();

            return Ok(administrador);
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.UsuarioId == id);
        }
    }
}