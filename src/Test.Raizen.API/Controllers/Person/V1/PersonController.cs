using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Raizen.API.Controllers.Person.V1;

[ApiVersion("1")]
public partial class PersonController : BaseController
{
    private readonly IMediator _mediator;

    public PersonController(IMediator mediator)
    {
        _mediator = mediator;
    }
}