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
    public class PlanoDeEnsinoesController : ControllerBase
    {
        private readonly APIContext _context;

        public PlanoDeEnsinoesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/PlanoDeEnsinoes
        [HttpGet]
        public IEnumerable<PlanoDeEnsino> GetPlanoDeEnsino()
        {
            return _context.PlanoDeEnsino;
        }

        // GET: api/PlanoDeEnsinoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanoDeEnsino([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var planoDeEnsino = await _context.PlanoDeEnsino.FindAsync(id);

            if (planoDeEnsino == null)
            {
                return NotFound();
            }

            return Ok(planoDeEnsino);
        }

        // PUT: api/PlanoDeEnsinoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanoDeEnsino([FromRoute] int id, [FromBody] PlanoDeEnsino planoDeEnsino)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planoDeEnsino.PlanoEnsinoId)
            {
                return BadRequest();
            }

            _context.Entry(planoDeEnsino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanoDeEnsinoExists(id))
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

        // POST: api/PlanoDeEnsinoes
        [HttpPost]
        public async Task<IActionResult> PostPlanoDeEnsino([FromBody] PlanoDeEnsino planoDeEnsino)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlanoDeEnsino.Add(planoDeEnsino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanoDeEnsino", new { id = planoDeEnsino.PlanoEnsinoId }, planoDeEnsino);
        }

        // DELETE: api/PlanoDeEnsinoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanoDeEnsino([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var planoDeEnsino = await _context.PlanoDeEnsino.FindAsync(id);
            if (planoDeEnsino == null)
            {
                return NotFound();
            }

            _context.PlanoDeEnsino.Remove(planoDeEnsino);
            await _context.SaveChangesAsync();

            return Ok(planoDeEnsino);
        }

        private bool PlanoDeEnsinoExists(int id)
        {
            return _context.PlanoDeEnsino.Any(e => e.PlanoEnsinoId == id);
        }
    }
}