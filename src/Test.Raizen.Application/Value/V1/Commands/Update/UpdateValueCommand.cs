using System;
using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Value.V1.Commands.Update
{
    public class UpdateValueCommand : CommandBase<UpdateValueCommand>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public UpdateValueCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
