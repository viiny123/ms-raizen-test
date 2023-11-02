using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;

namespace Test.Raizen.Data.Configuration.Seeds.Value
{
    [ExcludeFromCodeCoverage]
    public class ValueSeed : IEntityTypeConfiguration<Domain.AggregatesModel.ValueAggreate.Value>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.ValueAggreate.Value> builder)
        {
            builder.HasData(
                PopulateStatus(Guid.Parse("b5d23923-27e5-42b2-a027-a96685097686"), "Code-1", "Description-1", Status.Active),
                PopulateStatus(Guid.Parse("f580dd1f-709a-4a73-98a7-d296f3ef5c7b"), "Code-2", "Description-2", Status.Active),
                PopulateStatus(Guid.Parse("42f30e82-4ca0-4172-abc3-5fc14e5c0559"), "Code-3", "Description-3", Status.Active)
           );
        }

        private static Domain.AggregatesModel.ValueAggreate.Value PopulateStatus(Guid id, string code, string description, Status status)
        {
            return new Domain.AggregatesModel.ValueAggreate.Value()
            {
                Id = id,
                Code = code,
                Description = description,
                Status = status
            };
        }
    }
}
