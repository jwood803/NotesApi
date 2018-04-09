using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddAsync(Note entity)
        {
            _dbContext.Add(entity);
        
            var rowsAffected = await _dbContext.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(Note note)
        {
            var noteToDelete = _dbContext.Attach(note);

            noteToDelete.State = EntityState.Deleted;

            var rowsAffected = await _dbContext.SaveChangesAsync();

            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _dbContext.Note.ToListAsync();
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            var note = await _dbContext.Note.FindAsync(id);

            return note;
        }

        public async Task<bool> UpdateAsync(Note entity)
        {
            var noteToUpdate = _dbContext.Update(entity);

            noteToUpdate.State = EntityState.Modified;

            var rowsAffected = await _dbContext.SaveChangesAsync();

            return rowsAffected > 0;
        }
    }
}
