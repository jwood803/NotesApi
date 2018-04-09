using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Data;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        public NotesRepository _repository { get; }

        public NotesController()
        {
            _repository = new NotesRepository();
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> GetNotes()
        {
            var items = await _repository.GetAllAsync();

            return items;
        }

        [HttpGet("{id}")]
        public async Task<Note> GetNoteById(int id)
        {
            var note = await _repository.GetByIdAsync(id);

            return note;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote([FromBody]Note note)
        {
            var noteWithId = await _repository.GetByIdAsync(note.Id);

            if(noteWithId != null)
            {
                return new JsonResult("Note already exists");
            }

            await _repository.AddAsync(note);

            return new StatusCodeResult(200);
        }

        [HttpPut("{noteId}")]
        public async Task<IActionResult> EditNote(int noteId, [FromBody]Note note)
        {
            var noteToUpdate = await _repository.GetByIdAsync(noteId);

            if (noteToUpdate == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(note);

            return new StatusCodeResult(200);
        }

        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            var note = await _repository.GetByIdAsync(noteId);

            if(note == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(note);

            return new StatusCodeResult(200);
        }
    }
}