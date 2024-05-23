using ExamProgram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProgram.Data.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(20)");
        builder.Property(x => x.Surname).IsRequired().HasColumnType("nvarchar(20)");
    }
}
