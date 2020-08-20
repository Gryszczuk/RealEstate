using Microsoft.EntityFrameworkCore;
using RealEstateScrapper.Models;
using RealEstateScrapper.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RealEstateScrapper.DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly RealEstateContext _context;
        private DbSet<T> entites;
        public Repository(RealEstateContext context)
        {
            _context = context;
            entites = context.Set<T>();
        }

        public async Task Add(T model)
        {
            await entites.AddAsync(model);
        }

        public async Task AddMany(IEnumerable<T> models)
        {
             await entites.AddRangeAsync(models);
        }

        public async Task Delete(T model)
        {
            entites.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id)
        {
           return await entites.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task Update(T model)
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await entites.Where(x => x.IsActive).ToListAsync();
        }
    }
}
