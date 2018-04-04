using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NotesApi.Models;
using System.IO;
using System.Linq;

namespace NotesApi.Data
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Note { get; set; }

        public static IConfiguration Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var mySqlKey = Configuration.GetSection("Keys").GetValue("MySQL", "");

            optionsBuilder.UseMySql($"Server=localhost;database=notes;uid=root;pwd={mySqlKey}");
        }
    }
}
