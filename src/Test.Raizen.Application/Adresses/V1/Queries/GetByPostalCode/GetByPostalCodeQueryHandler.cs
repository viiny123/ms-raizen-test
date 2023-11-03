using System.Threading;
using System.Threading.Tasks;
using Test.Raizen.Application.Base;
using Test.Raizen.Application.Services.ViaCep.API;

namespace Test.Raizen.Application.Adresses.V1.Queries.GetByPostalCode;

public class GetByPostalCodeQueryHandler : HandlerBase<GetByPostalCodeQuery>
{
    private readonly IViaCepApi _viaCepApi;

    public GetByPostalCodeQueryHandler(IViaCepApi viaCepApi)
    {
        _viaCepApi = viaCepApi;
    }

    public override async Task<Result> Handle(GetByPostalCodeQuery request, CancellationToken cancellationToken)
    {
        var address = await _viaCepApi.GetAddressByPostalCodeAsync(request.PostalCode);

        Result.Data = (GetByPostalCodeResponse)address;

        return Result;
    }
}
