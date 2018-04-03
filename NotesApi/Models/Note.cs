using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }
        public bool IsFavorite { get; set; }
    }
}
