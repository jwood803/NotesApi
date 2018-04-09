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

            var mySqlKey = Configuration.GetSection("MySQL").GetValue("Password", "");
            var mySqlPort = Configuration.GetSection("MySQL").GetValue("Port", 0);

            optionsBuilder.UseMySql($"Server=10.0.75.1;port={mySqlPort};database=notes;uid=root;pwd={mySqlKey}");
        }
    }
}
