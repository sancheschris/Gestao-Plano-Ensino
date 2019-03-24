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
    public class ProfessoresController : ControllerBase
    {
        private readonly APIContext _context;

        public ProfessoresController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Professores
        [HttpGet]
        public IEnumerable<Professor> GetProfessor()
        {
            return _context.Professor;
        }

        // GET: api/Professores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _context.Professor.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // PUT: api/Professores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor([FromRoute] int id, [FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != professor.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // POST: api/Professores
        [HttpPost]
        public async Task<IActionResult> PostProfessor([FromBody] Professor professor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Professor.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessor", new { id = professor.UsuarioId }, professor);
        }

        // DELETE: api/Professores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professor.Remove(professor);
            await _context.SaveChangesAsync();

            return Ok(professor);
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.UsuarioId == id);
        }
    }
}