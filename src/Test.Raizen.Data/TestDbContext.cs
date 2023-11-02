using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Microsoft.EntityFrameworkCore;

namespace Test.Raizen.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);
    }
}
