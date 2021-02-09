using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library_Master.EntityFramework
{
    public class Library_MasterDbContextFactory : IDesignTimeDbContextFactory<Library_MasterDbContext>
    {
        public Library_MasterDbContext CreateDbContext(string[] args = null)
        {
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Library-Master\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            var options = new DbContextOptionsBuilder<Library_MasterDbContext>();
            options.UseSqlite($"Data Source={path}Database.db");

            return new Library_MasterDbContext(options.Options);
        }
    }
}