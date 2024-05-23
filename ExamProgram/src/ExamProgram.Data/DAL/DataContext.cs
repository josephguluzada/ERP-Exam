using ExamProgram.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Data.DAL;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
