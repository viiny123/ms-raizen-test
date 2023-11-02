using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Controllers.Value.V1.Create;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Value.V1.Commands.Create;
using Test.Raizen.Application.Value.V1.Events.SaveStatus;

namespace Test.Raizen.API.Controllers.Value.V1
{
    public partial class ValueController
    {
        /// <summary>
        /// Create value
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Value created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Bussiness rules violated</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpPost]
        [ProducesResponseType(typeof(CreateCommandValueResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateValueV1Async([FromBody] CreateValueRequest request)
        {

            var statusEvent = new SaveStatusEvent(request.Code, DateTime.Now);
            _ = mediator.Publish(statusEvent);

            CreateValueCommand command = request;
            var result = await mediator.Send(command);
            var response = BasePresenter.Cast(result, HttpStatusCode.Created);

            return response;
        }
    }
}
