using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column("is_favorite")]
        public bool IsFavorite { get; set; }
    }
}
