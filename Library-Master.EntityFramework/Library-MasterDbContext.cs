using Library_Master.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Master.EntityFramework
{
    public class Library_MasterDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaktion> Transactions { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<QrCode> QrCodes { get; set; }

        public Library_MasterDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Ignore(b => b.StrAntolin);
            modelBuilder.Entity<Book>().Ignore(b => b.StrPreis);
            modelBuilder.Entity<Book>().Ignore(b => b.StrMedium);
            base.OnModelCreating(modelBuilder);
        }
    }
}