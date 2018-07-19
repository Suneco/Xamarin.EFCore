using Microsoft.EntityFrameworkCore;
using Xamarin.EFCore.Entities;

namespace Xamarin.EFCore
{
    public class DatabaseContext : DbContext
    {
        private string DatabasePath { get; }

        /// <summary>
        /// Specify your entities here. Entity will automaticly migrate and add the entities to the database.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        public DatabaseContext(string databasePath)
        {
            DatabasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }
    }
}
