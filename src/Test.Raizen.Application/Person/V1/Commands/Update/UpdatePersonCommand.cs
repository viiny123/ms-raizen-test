using System;
using Test.Raizen.Application.Base;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Application.Person.V1.Commands.Update;

public class UpdatePersonCommand : CommandBase<UpdatePersonCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string PostalCode { get; set; }
    public Status Status { get; set; }

    public static implicit operator Domain.AggregatesModel.ValueAggreate.Person(UpdatePersonCommand command)
    {
        return new Domain.AggregatesModel.ValueAggreate.Person
        {
            Id = command.Id,
            Name = command.Name,
            Email = command.Email,
            BirthDay = command.BirthDay,
            PostalCode = command.PostalCode,
            Status = command.Status
        };
    }
}
