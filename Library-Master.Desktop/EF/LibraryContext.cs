using Library_Master.Desktop.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_Master.Desktop.EF
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=data.db");
        }
    }
}