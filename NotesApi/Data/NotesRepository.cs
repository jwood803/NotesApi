using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Data
{
    public class NotesRepository : IRepository<Note>
    {
        public NotesRepository()
        {
            _dbContext = new NotesContext();
        }

        public NotesContext _dbContext { get; }

        public bool Add(Note entity)
        {
            _dbContext.Add(entity);
        
            var rowsAffected = _dbContext.SaveChanges();

            return rowsAffected > 0;
        }

        public bool Delete(Note note)
        {
            var noteToDelete = _dbContext.Attach(note);

            noteToDelete.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            var rowsAffected = _dbContext.SaveChanges();

            return rowsAffected > 0;
        }

        public IEnumerable<Note> GetAll()
        {
            return _dbContext.Note.ToList();
        }

        public Note GetById(int id)
        {
            var note = _dbContext.Note.Find(id);

            return note;
        }

        public bool Update(Note entity)
        {
            throw new NotImplementedException();
        }
    }
}
