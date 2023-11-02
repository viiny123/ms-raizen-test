using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test.Raizen.Domain.Base
{
    public interface IRepositoryBase<TEntity>
    {
        Task<TEntity> GetById(Guid id);

        Task<IEnumerable<TEntity>> GetAll(IEnumerable<Expression<Func<TEntity, bool>>> predicates);

        Task Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
