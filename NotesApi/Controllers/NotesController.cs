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
        public bool AddNote(Note note)
        {
            return true;
        }

        [HttpPut]
        public bool EditNote(Note note)
        {
            return true;
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

            return new NoContentResult();
        }
    }
}