using Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
    {
        IDbSet<TEntity> _objectSet;
        IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _objectSet = unitOfWork.CreateSet<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            TEntity newEntity = (TEntity)_objectSet.Add(entity);
            return newEntity;
        }

        public TEntity Get(TKey id)
        {
            return _objectSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _objectSet.ToList();
        }

        public virtual void Remove(TKey id)
        {
            var entity = _objectSet.Find(id);
            _objectSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.SetModified(entity);
        }
    }
}
