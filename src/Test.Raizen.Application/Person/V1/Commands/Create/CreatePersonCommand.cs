using System;
using Test.Raizen.Application.Base;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Application.Person.V1.Commands.Create;

public class CreatePersonCommand : CommandBase<CreatePersonCommand>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string PostalCode { get; set; }

    public static implicit operator Domain.AggregatesModel.ValueAggreate.Person(CreatePersonCommand command) => new()
    {
        Name = command.Name,
        PostalCode = command.PostalCode,
        Status = Status.Active,
        CreateAt = DateTime.Now,
        BirthDay = command.BirthDay,
        Email = command.Email
    };
}
