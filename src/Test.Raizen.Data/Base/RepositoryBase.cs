using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Raizen.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Test.Raizen.Data.Base
{
    public abstract class RepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity>
        where TEntity : EntityBase<TEntity>
        where TContext : DbContext
    {
        internal readonly Func<DbConnections, IDbConnection> dbConnectionFactory;
        internal TContext context;
        internal DbSet<TEntity> DbSet;

        protected RepositoryBase(TContext context,
            Func<DbConnections, IDbConnection> dbConnectionFactory)
        {
            this.context = context;
            this.dbConnectionFactory = dbConnectionFactory;
            DbSet = this.context.Set<TEntity>();
        }

        protected RepositoryBase(Func<DbConnections, IDbConnection> dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await context.Set<TEntity>()
                .FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll(IEnumerable<Expression<Func<TEntity, bool>>> predicates)
        {
            var queryableEntity = context.Set<TEntity>()
                .AsQueryable();

            foreach (var predicate in predicates)
            {
                queryableEntity = queryableEntity.Where(predicate);
            }

            return await queryableEntity.ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

    }
}
