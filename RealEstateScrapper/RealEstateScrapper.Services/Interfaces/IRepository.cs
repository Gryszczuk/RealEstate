using RealEstateScrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetById(Guid id);
        Task Add(T model);
        Task AddMany(IEnumerable<T> models);
        Task Delete(T model);
        Task Update(T model);
        Task<IEnumerable<T>> GetAll();
    }
}
