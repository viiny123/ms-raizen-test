using System.Diagnostics.CodeAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Raizen.API.Controllers.Value.V1
{
    [ExcludeFromCodeCoverage]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    [ProducesErrorResponseType(typeof(void))]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("[controller]")]
    [ApiVersion("1")]
    public partial class ValueController : ControllerBase
    {
        private readonly IMediator mediator;

        public ValueController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
