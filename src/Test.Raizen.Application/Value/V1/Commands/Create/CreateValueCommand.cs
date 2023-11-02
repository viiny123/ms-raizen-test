using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Value.V1.Commands.Create
{
    public class CreateValueCommand : CommandBase<CreateValueCommand>
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public CreateValueCommand(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
