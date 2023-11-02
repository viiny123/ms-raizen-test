using System;
using Test.Raizen.Application.Person.V1.Commands.Create;

namespace Test.Raizen.API.Controllers.Person.V1.Create;

public class CreatePersonRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string PostalCode { get; set; }

    public static implicit operator CreatePersonCommand(CreatePersonRequest request)
    {
        return new CreatePersonCommand
        {
            Name = request.Name,
            Email = request.Email,
            BirthDay = request.BirthDay,
            PostalCode = request.PostalCode
        };
    }
}
