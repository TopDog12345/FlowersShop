using Slobodianiuk.University.Example.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slobodianuik.University.Example.Database.Interfaces
{
    public interface IDbEntityService<T> : IDisposable where T : DbItem
    {
        Task<T?> GetById(int id);
        T GetByIdforUser(long id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task Delete(T entity);

        IQueryable<T> GetAll();
    }
}
