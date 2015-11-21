using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TKey id);
        TEntity Add(TEntity entity);
        void Remove(TKey id);
        void Update(TEntity entity);
    }
}
