using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Master.Core.Models;
using Library_Master.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library_Master.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DefaultObject
    {
        private readonly Library_MasterDbContextFactory _contextFactory;

        public GenericDataService(Library_MasterDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (Library_MasterDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult  = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }
        
        public async Task<bool> Delete(int id)
        {
            using (Library_MasterDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }
        
        public async Task<T> Get(int id)
        {
            using (Library_MasterDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                Type type = typeof(T);
                if (type == typeof(Account))
                {
                    await context.Set<Account>().Include(c => c.Transaktionen).ToListAsync();
                }
                return entity;
            }
        }
        
        public async Task<ICollection<T>> GetAll()
        {
            using (Library_MasterDbContext context = _contextFactory.CreateDbContext())
            {
                ICollection<T> entities = await context.Set<T>().ToListAsync();
                Type type = typeof(T);
                if (type == typeof(Account))
                {
                    await context.Set<Account>().Include(c => c.Transaktionen).ToListAsync();
                }
                return entities;
            }
        }
        
        public async Task<T> Update(int id, T entity)
        {
            using (Library_MasterDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                
                return entity;
            }
        }
        
        
    }
}