using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Controllers.Person.V1.Create;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Person.V1.Commands.Create;

namespace Test.Raizen.API.Controllers.Person.V1;

public partial class PersonController
{
    /// <summary>
    /// Create Person
    /// </summary>
    /// <returns></returns>
    /// <response code="201">Value created</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpPost]
    [ProducesResponseType(typeof(CreateCommandPersonResponse), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreatePersonV1Async([FromBody] CreatePersonRequest request)
    {
        CreatePersonCommand command = request;
        var result = await _mediator.Send(command);
        var response = BasePresenter.Cast(result, HttpStatusCode.Created);

        return response;
    }
}
