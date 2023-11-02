using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Domain.AggregatesModel.ValueAggreate
{
    public interface IValueRepository : IRepositoryBase<Value>
    {
        Task<Value> GetValueByIdAsync(Guid id);
        Task<IEnumerable<Value>> GetValuesAsync(string code, string description);

        Task<Paginate<Value>> GetValuePaginated(IEnumerable<Expression<Func<Value, bool>>> predicates,
                                                Paginate<Value> paginate);
    }
}
