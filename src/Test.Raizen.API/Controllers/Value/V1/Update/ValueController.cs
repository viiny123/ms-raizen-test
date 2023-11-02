using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Controllers.Value.V1.Update;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Value.V1.Commands.Create;
using Test.Raizen.Application.Value.V1.Commands.Update;

namespace Test.Raizen.API.Controllers.Value.V1
{
    public partial class ValueController
    {
        /// <summary>
        /// Update value
        /// </summary>
        /// <param name="id">Unique identifier of Value</param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="204">Value update</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Bussiness rules violated</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CreateCommandValueResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateValueV1Async([FromRoute] Guid id,
            [FromBody] UpdateValueRequest request)
        {
            var command = new UpdateValueCommand(id, request.Description);
            var result = await mediator.Send(command);
            var response = BasePresenter.Cast(result, HttpStatusCode.NoContent);

            return response;
        }
    }
}
