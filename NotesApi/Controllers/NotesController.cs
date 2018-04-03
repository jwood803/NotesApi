using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        [HttpGet]
        public IEnumerable<Note> GetNotes()
        {
            return new List<Note>
            {
                new Note { Id=1, Details="Details", Title="New book" }
            };
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