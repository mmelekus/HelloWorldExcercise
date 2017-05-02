using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldInfrastructure
{
    interface IRepositoryKey<TEntity, TKey> : IRepository<TEntity>
    {
        IEnumerable<TEntity> GetItem(TKey id);
        void DeleteByKey(TKey id);
    }
}
