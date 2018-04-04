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

        public void Add(Note entity)
        {
            _dbContext.Add(entity);
        
            _dbContext.SaveChanges();
        }

        public void Delete(Note entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> GetAll()
        {
            return _dbContext.Note.ToList();
        }

        public Note GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            throw new NotImplementedException();
        }
    }
}
