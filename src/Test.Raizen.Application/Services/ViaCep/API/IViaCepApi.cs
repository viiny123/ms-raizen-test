using System.Threading.Tasks;
using Refit;
using Test.Raizen.Application.Services.ViaCep.API.Responses;

namespace Test.Raizen.Application.Services.ViaCep.API;

public interface IViaCepApi
{
    [Get("/{postalCode}/json/")]
    Task<AddressResponseApi> GetAddressByPostalCodeAsync(string postalCode);
}
