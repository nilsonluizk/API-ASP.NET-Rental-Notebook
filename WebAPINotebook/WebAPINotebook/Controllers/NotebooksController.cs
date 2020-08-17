using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPINotebook;
using WebAPINotebook.Models;

namespace WebAPINotebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotebooksController : ControllerBase
    {
        private readonly Context _context;

        public NotebooksController(Context context)
        {
            _context = context;
        }

        // GET: api/Notebooks
        [HttpGet("listanotebook")]
        public async Task<ActionResult<IEnumerable<Notebook>>> ListaNotebooks()
        {
            return await _context.Notebooks.ToListAsync();
        }

        // GET: api/Notebooks/5
        [HttpGet("listanotebookbyid/{id}")]
        public async Task<ActionResult<Notebook>> ListaNotebookById(int id)
        {
            var notebook = await _context.Notebooks.FindAsync(id);

            if (notebook == null)
            {
                return NotFound();
            }

            return notebook;
        }

        // PUT: api/Notebooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("Atualizarnotebook/{id}")]
        [Authorize(Roles = "gerente")]
        public async Task<IActionResult> AtualizarNotebook(int id, Notebook notebook)
        {
            if (id != notebook.Id)
            {
                return BadRequest();
            }

            _context.Entry(notebook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotebookExists(id))
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

        // POST: api/Notebooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("inserirnotebook")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<Notebook>> InserirNotebook(Notebook notebook)
        {
            _context.Notebooks.Add(notebook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ListaNotebooks", new { id = notebook.Id }, notebook);
        }

        // DELETE: api/Notebooks/5
        [HttpDelete("deletarnotebook/{id}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<Notebook>> DeletarNotebook(int id)
        {
            var notebook = await _context.Notebooks.FindAsync(id);
            if (notebook == null)
            {
                return NotFound();
            }

            _context.Notebooks.Remove(notebook);
            await _context.SaveChangesAsync();

            return notebook;
        }

        private bool NotebookExists(int id)
        {
            return _context.Notebooks.Any(e => e.Id == id);
        }
    }
}
