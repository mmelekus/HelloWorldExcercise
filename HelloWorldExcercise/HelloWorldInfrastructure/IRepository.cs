using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorldInfrastructure
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        void AddNew(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
