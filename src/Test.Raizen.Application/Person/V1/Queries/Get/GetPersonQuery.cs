using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Person.V1.Queries.Get;

public class GetPersonQuery : QueryBase<GetPersonQuery>
{
    public string Name { get; set; }
    public string Email { get; set; }

    public GetPersonQuery(
        string name,
        string email)
    {
        Name = name;
        Email = email;
    }

    public GetPersonQuery WithPaginated(int pageSize, int pageNumber)
    {
        PageNumber = pageNumber;
        PageSize = pageSize > 10 ? 10 : pageSize;

        return this;
    }
}
