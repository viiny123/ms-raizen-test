using System;
using Test.Raizen.Application.Person.V1.Commands.Update;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.API.Controllers.Person.V1.Update;

public class UpdatePersonRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string PostalCode { get; set; }
    public Status Status { get; set; }

    public static implicit operator UpdatePersonCommand(UpdatePersonRequest request)
    {
        return new UpdatePersonCommand
        {
            Name = request.Name,
            Email = request.Email,
            BirthDay = request.BirthDay,
            PostalCode = request.PostalCode,
            Status = request.Status
        };
    }
}
