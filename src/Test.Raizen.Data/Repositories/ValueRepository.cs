using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Test.Raizen.Data.Base;
using Test.Raizen.Data.Configuration.Mappings;

namespace Test.Raizen.Data.Repositories;

public class ValueRepository : RepositoryBase<TestDbContext, Value>, IValueRepository
{

    private static readonly string GET_VALUE = @"SELECT
                                                        Id,
                                                        Code,
                                                        Description,
                                                        Status,
                                                        [Timestamp]
                                                    FROM
                                                        Value
                                                    WHERE
                                                        (@code is null or Code = @code ) AND
                                                        (@description is null or Description = @description )";

    private static readonly string GET_VALUE_BY_ID = @"SELECT
                                                            Id,
                                                            Code,
                                                            Description,
                                                            Status,
                                                            [Timestamp]
                                                        FROM
                                                            Value
                                                        WHERE
                                                            Id = @id";

    public ValueRepository(TestDbContext context,
        Func<DbConnections, IDbConnection> dbConnectionFactory) : base(context, dbConnectionFactory)
    {
    }

    public async Task<Value> GetValueByIdAsync(Guid id)
    {
        using var connection = dbConnectionFactory.Invoke(DbConnections.DEFAULT_CONNECTION);
        var result = await connection.QueryAsync<Value>(
            sql: GET_VALUE_BY_ID,
            param: new
            {
                id
            });

        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<Value>> GetValuesAsync(string code, string description)
    {
        using var connection = dbConnectionFactory.Invoke(DbConnections.DEFAULT_CONNECTION);
        var result = await connection.QueryAsync<Value>(
            sql: GET_VALUE,
            param: new
            {
                code = new DbString { Value = code, IsAnsi = false, IsFixedLength = true, Length = ValueMap.VALUE_CODE_LENGTH },
                description = new DbString { Value = description, IsAnsi = false, IsFixedLength = true, Length = ValueMap.VALUE_DESCRIPTION_LENGTH },
            });

        return result;
    }

    public async Task<Paginate<Value>> GetValuePaginated(IEnumerable<Expression<Func<Value, bool>>> predicates,
        Paginate<Value> paginate)
    {

        var queryableValue = context.Value
            .AsQueryable();

        foreach (var predicate in predicates)
        {
            queryableValue = queryableValue.Where(predicate);
        }

        //total items
        paginate.TotalCount = await queryableValue.LongCountAsync();

        //Pagination and result
        var values = await queryableValue
            .OrderByDescending(x => x.Timestamp)
            .Skip(paginate.GetSkip())
            .Take(paginate.PageSize)
            .ToListAsync();

        paginate.PageData = values;
        paginate.TotalPage = paginate.GetTotalPage();

        return paginate;

    }
}
