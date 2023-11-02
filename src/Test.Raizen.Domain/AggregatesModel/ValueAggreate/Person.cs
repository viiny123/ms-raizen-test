using System;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Domain.AggregatesModel.ValueAggreate;

public class Person : EntityBase<Person>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDay { get; set; }
    public string PostalCode { get; set; }
    public Status Status { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
}