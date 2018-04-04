using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Note> GetNotes()
        {
            var items = _repository.GetAll();

            return items;
        }

        [HttpGet("{id}")]
        public Note GetNoteById(int id)
        {
            var note = _repository.GetById(id);

            return note;
        }

        [HttpPost]
        public IActionResult AddNote([FromBody]Note note)
        {
            var noteWithId = _repository.GetById(note.Id);

            if(noteWithId != null)
            {
                return new JsonResult("Note already exists");
            }

            _repository.Add(note);

            return new StatusCodeResult(200);
        }

        [HttpPut("{noteId}")]
        public IActionResult EditNote(int noteId, [FromBody]Note note)
        {
            var noteToUpdate = _repository.GetById(noteId);

            if (noteToUpdate == null)
            {
                return NotFound();
            }

            _repository.Update(note);

            return new StatusCodeResult(200);
        }

        [HttpDelete("{noteId}")]
        public IActionResult DeleteNote(int noteId)
        {
            var note = _repository.GetById(noteId);

            if(note == null)
            {
                return NotFound();
            }

            _repository.Delete(note);

            return new StatusCodeResult(200);
        }
    }
}