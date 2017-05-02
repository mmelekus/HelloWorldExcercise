using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldInfrastructure
{
    public class Repository<TEntity> : IDisposable where TEntity : class
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
