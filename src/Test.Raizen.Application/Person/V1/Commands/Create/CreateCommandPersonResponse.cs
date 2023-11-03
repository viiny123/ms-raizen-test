using System;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Application.Person.V1.Commands.Create;

public class CreateCommandPersonResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string PostalCode { get; set; }
    public Status Status { get; set; }
    public DateTime CreateAt { get; set; }

    public static implicit operator CreateCommandPersonResponse(Domain.AggregatesModel.ValueAggreate.Person entity) => new()
    {
        Name = entity.Name,
        PostalCode = entity.PostalCode,
        Status = Status.Active,
        CreateAt = DateTime.Now,
        BirthDay = entity.BirthDay,
        Email = entity.Email,
        Id = entity.Id
    };
}
