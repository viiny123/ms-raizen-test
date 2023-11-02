using System.Diagnostics.CodeAnalysis;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Raizen.Data.Configuration.Mappings;

[ExcludeFromCodeCoverage]
public class ValueMap : IEntityTypeConfiguration<Value>
{
    public const int VALUE_CODE_LENGTH = 45;
    public const int VALUE_DESCRIPTION_LENGTH = 120;

    public void Configure(EntityTypeBuilder<Value> builder)
    {
        builder.ToTable("Value");

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(e => e.Code)
            .HasColumnName("Code")
            .IsUnicode(false)
            .HasMaxLength(VALUE_CODE_LENGTH);

        builder.Property(e => e.Description)
            .IsUnicode(false)
            .HasColumnName("Description")
            .HasMaxLength(VALUE_DESCRIPTION_LENGTH);

        builder.Property(e => e.Status)
            .HasColumnName("Status")
            .IsUnicode(false)
            .HasConversion<string>()
            .HasDefaultValue(Status.Active);

        builder.Property(e => e.Timestamp)
            .HasColumnName("Timestamp")
            .HasColumnType("Datetime")
            .HasDefaultValueSql("(getdate())");
    }
}
