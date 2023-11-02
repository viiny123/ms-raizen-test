using System;
using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Person.V1.Queries.GetById;

public class GetPersonByIdQuery : QueryBase<GetPersonByIdQuery>
{
    public Guid Id { get; set; }

    public GetPersonByIdQuery(Guid id)
    {
        Id = id;
    }
}
