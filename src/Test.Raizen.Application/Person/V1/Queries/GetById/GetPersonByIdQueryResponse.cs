using System;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Application.Person.V1.Queries.GetById;

public class GetPersonByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string PostalCode { get; set; }
    public Status Status { get; set; }

    public static implicit operator GetPersonByIdQueryResponse(Domain.AggregatesModel.ValueAggreate.Person person) => new()
    {
        Id = person.Id,
        Name = person.Name,
        Email = person.Email,
        BirthDay = person.BirthDay,
        PostalCode = person.PostalCode,
        Status = person.Status
    };
}
