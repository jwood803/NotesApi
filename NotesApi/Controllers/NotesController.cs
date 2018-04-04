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

        [HttpDelete]
        public bool DeleteNote(int noteId)
        {
            return true;
        }
    }
}