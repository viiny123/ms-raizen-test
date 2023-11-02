using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Controllers.Person.V1.Update;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Person.V1.Commands.Create;
using Test.Raizen.Application.Person.V1.Commands.Delete;
using Test.Raizen.Application.Person.V1.Commands.Update;

namespace Test.Raizen.API.Controllers.Person.V1;

public partial class PersonController
{
    /// <summary>
    /// Update value
    /// </summary>
    /// <param name="id">Unique identifier of Value</param>
    /// <returns></returns>
    /// <response code="204">Person deleted</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateValueV1Async([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new DeletePersonCommand
        {
            Id = id
        });

        var response = BasePresenter.Cast(result, HttpStatusCode.NoContent);

        return response;
    }
}
