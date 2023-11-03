using Test.Raizen.Application.Services.ViaCep.API.Responses;

namespace Test.Raizen.Application.Adresses.Queries.GetByPostalCode;

public class GetByPostalCodeResponse
{
    public string PostalCode { get; set; }

    public string Street { get; set; }

    public string Complement { get; set; }

    public string Neighborhood { get; set; }

    public string Location { get; set; }

    public string State { get; set; }

    public string Ibge { get; set; }

    public string Gia { get; set; }

    public string Ddd { get; set; }

    public string Siafi { get; set; }

    public static implicit operator GetByPostalCodeResponse(AddressResponseApi response) => new()
    {
        Complement = response.Complement,
        Ddd = response.Ddd,
        Gia = response.Gia,
        Ibge = response.Ibge,
        Location = response.Location,
        Neighborhood = response.Neighborhood,
        Siafi = response.Siafi,
        State = response.State,
        Street = response.Street,
        PostalCode = response.PostalCode
    };
}
