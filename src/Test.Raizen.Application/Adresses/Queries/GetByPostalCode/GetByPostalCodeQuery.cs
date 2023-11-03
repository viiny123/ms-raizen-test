using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Adresses.Queries.GetByPostalCode;

public class GetByPostalCodeQuery : QueryBase<GetByPostalCodeQuery>
{
    public string PostalCode { get; set; }
}
