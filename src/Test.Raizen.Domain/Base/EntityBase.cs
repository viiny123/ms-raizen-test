using System;

namespace Test.Raizen.Domain.Base
{
    public abstract class EntityBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Unique identifier of entity
        /// </summary>
        public virtual Guid Id { get; set; }
    }
}
