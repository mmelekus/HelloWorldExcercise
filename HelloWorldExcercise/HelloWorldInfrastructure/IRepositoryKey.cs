using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorldInfrastructure
{
    public interface IRepositoryKey<TEntity, TKey> : IRepository<TEntity>
    {
        IQueryable<TEntity> GetItem(TKey id);
        void DeleteByKey(TKey id);
    }
}
