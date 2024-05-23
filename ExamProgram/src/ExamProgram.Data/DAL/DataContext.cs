using Microsoft.EntityFrameworkCore;

namespace ExamProgram.Data.DAL;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
}
