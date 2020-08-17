using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPINotebook.Models;

namespace WebAPINotebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlugarNotebooksController : ControllerBase
    {
        private readonly Context _context;

        public AlugarNotebooksController(Context context)
        {
            _context = context;
        }

        // GET: api/AlugarNotebooks
        [HttpGet("listacliente")]
        public async Task<ActionResult<IEnumerable<AlugarNotebook>>> ObterListaClientesNotebooks()
        {
            return await _context.AlugarNotebooks.Include("Notebook").ToListAsync();
        }

        // GET: api/AlugarNotebooks/5
        [HttpGet("listaclienteby/{id}")]
        public async Task<ActionResult<AlugarNotebook>> ListaClienteNotebook(int id)
        {
            var alugarNotebook = await _context.AlugarNotebooks.Include("Notebook").FirstOrDefaultAsync(x => x.Id == id);

            if (alugarNotebook == null)
            {
                return NotFound();
            }

            return alugarNotebook;
        }

        // PUT: api/AlugarNotebooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("atualizarcliente/{id}")]
        [Authorize(Roles = "gerente")]
        public async Task<IActionResult> AtualizarClienteAlugarNotebook(int id, AlugarNotebook alugarNotebook)
        {
            if (id != alugarNotebook.Id)
            {
                return BadRequest();
            }

            _context.Entry(alugarNotebook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlugarNotebookExists(id))
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

        // POST: api/AlugarNotebooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Inserircliente")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<AlugarNotebook>> InserirClienteAluguelNotebook(AlugarNotebook alugarNotebook)
        {
            _context.AlugarNotebooks.Add(alugarNotebook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ObterListaClientesNotebooks", new { id = alugarNotebook.Id }, alugarNotebook);
        }

        // DELETE: api/AlugarNotebooks/5
        [HttpDelete("deletarcliente/{id}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<AlugarNotebook>> DeleteAlugarNotebook(int id)
        {
            var alugarNotebook = await _context.AlugarNotebooks.FindAsync(id);
            if (alugarNotebook == null)
            {
                return NotFound();
            }

            _context.AlugarNotebooks.Remove(alugarNotebook);
            await _context.SaveChangesAsync();

            return alugarNotebook;
        }

        private bool AlugarNotebookExists(int id)
        {
            return _context.AlugarNotebooks.Any(e => e.Id == id);
        }
    }
}
