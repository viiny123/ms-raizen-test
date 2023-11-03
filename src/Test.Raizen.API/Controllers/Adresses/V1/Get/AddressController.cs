using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Raizen.API.Presenters;
using Test.Raizen.Application.Adresses.V1.Queries.GetByPostalCode;
using Test.Raizen.Application.Base.Error;

namespace Test.Raizen.API.Controllers.Adresses.V1;

public partial class AddressController
{
    /// <summary>
    /// Get address by postal code
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Value</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Internal Server Errror</response>
    [HttpGet("{postalCode}")]
    [ProducesResponseType(typeof(GetByPostalCodeResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ResponseError<ErrorDetail>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetValueByIdV1Async([FromRoute] string postalCode)
    {
        var queryRequest = new GetByPostalCodeQuery
        {
            PostalCode = postalCode
        };

        var result = await _mediator.Send(queryRequest);
        var response = BasePresenter.Cast(result, HttpStatusCode.OK);

        return response;
    }
}
