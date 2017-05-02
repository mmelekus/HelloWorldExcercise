using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldInfrastructure
{
    interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void AddNew(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
