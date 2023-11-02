using System;
using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Person.V1.Commands.Delete;

public class DeletePersonCommand : CommandBase<DeletePersonCommand>
{
    public Guid Id { get; set; }
}
