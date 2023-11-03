using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Extensions;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Base.Error;
using Test.Raizen.Application.Person.V1.Queries.Get;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.API.Controllers.Person.V1;

public partial class PersonController
{
    /// <summary>
    /// Get values
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="pageNumber"> Number of page</param>
    /// <param name="pageSize"> Max 10</param>
    /// <returns></returns>
    /// <response code="200">List of values</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<GetPersonQueryResponse>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetPersonsV1Async(
        [FromQuery] string name,
        [FromQuery] string email,
        [FromHeader(Name = "x-page-number")] int pageNumber = 1,
        [FromHeader(Name = "x-page-size")] int pageSize = 10)
    {
        var queryRequest = new GetPersonQuery(name, email)
            .WithPaginated(pageSize, pageNumber);
        var result = await _mediator.Send(queryRequest);

        var dataPaginate = (Paginate<GetPersonQueryResponse>)result.Data;

        Response.Headers.AddPaginationData(dataPaginate);

        var response = BasePresenter.Cast(dataPaginate.PageData, HttpStatusCode.OK);

        return response;
    }
}
