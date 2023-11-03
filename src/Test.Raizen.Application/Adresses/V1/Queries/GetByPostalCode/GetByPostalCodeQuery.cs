using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Adresses.V1.Queries.GetByPostalCode;

public class GetByPostalCodeQuery : QueryBase<GetByPostalCodeQuery>
{
    public string PostalCode { get; set; }
}
