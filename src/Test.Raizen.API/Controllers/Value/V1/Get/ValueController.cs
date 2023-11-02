using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Extensions;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Value.V1.Queries.Get;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.API.Controllers.Value.V1
{
    public partial class ValueController
    {
        /// <summary>
        /// Get values
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        /// <param name="emitError"></param>
        /// <param name="pageNumber"> Number of page</param>
        /// <param name="pageSize"> Max 10</param>
        /// <returns></returns>
        /// <response code="200">List of values</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpGet]
        [ProducesResponseType(typeof(GetValueQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetValuesV1Async([FromQuery] string code,
            [FromQuery] string description,
            [FromQuery] bool emitError,
            [FromHeader(Name = "x-page-number")] int pageNumber = 1,
            [FromHeader(Name = "x-page-size")] int pageSize = 10)
        {
            if (emitError)
            {
#pragma warning disable CA2201 // Do not raise reserved exception types
                throw new System.Exception("Standard error response");
#pragma warning restore CA2201 // Do not raise reserved exception types
            }

            var queryRequest = new GetValueQuery(code, description)
                .WithPaginated(pageSize, pageNumber);
            var result = await mediator.Send(queryRequest);

            var dataPaginate = (Paginate<GetValueQueryResponse>)result.Data;

            Response.Headers.AddPaginationData(dataPaginate);

            var response = BasePresenter.Cast(dataPaginate.PageData, HttpStatusCode.OK);

            return response;
        }
    }
}
