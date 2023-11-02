using System.Diagnostics.CodeAnalysis;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Raizen.Data.Configuration.Mappings;

[ExcludeFromCodeCoverage]
public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasMaxLength(150);

        builder.Property(e => e.Email)
            .HasMaxLength(100);

        builder.Property(e => e.BirthDay);

        builder.Property(e => e.PostalCode)
               .HasMaxLength(8);

        builder.Property(e => e.Status)
            .HasColumnName("Status")
            .HasConversion<string>()
            .HasDefaultValue(Status.Active);

        builder.Property(e => e.CreateAt)
            .HasDefaultValueSql("(getdate())");
    }
}
