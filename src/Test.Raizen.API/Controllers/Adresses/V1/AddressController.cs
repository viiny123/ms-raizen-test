using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.Raizen.API.Controllers.Adresses.V1;

[ApiVersion("1")]
public partial class AddressController : BaseController
{
    private readonly IMediator _mediator;

    public AddressController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
