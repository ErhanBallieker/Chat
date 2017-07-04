using Chat.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        int Count { get; }
        IQueryable<T> TableAll { get; }
        IQueryable<T> Table { get; }
        T GetById(int id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(int entityId);
    }
}
