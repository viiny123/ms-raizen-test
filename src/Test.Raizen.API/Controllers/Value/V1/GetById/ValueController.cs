using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Value.V1.Queries.GetById;

namespace Test.Raizen.API.Controllers.Value.V1
{
    public partial class ValueController
    {
        /// <summary>
        /// Get value
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Value</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetValueByIdQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetValueByIdV1Async([FromRoute] Guid id)
        {
            var queryRequest = new GetValueByIdQuery(id);
            var result = await mediator.Send(queryRequest);
            var response = BasePresenter.Cast(result, HttpStatusCode.OK);

            return response;
        }
    }
}
