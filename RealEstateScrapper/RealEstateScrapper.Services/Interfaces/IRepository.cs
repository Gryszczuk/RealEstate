using RealEstateScrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateScrapper.Services.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(Guid id);
        void Add(T model);
        void AddMany(IEnumerable<T> models);
        void Delete(T model);
        void Update(T model);
    }
}
