using ExamProgram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProgram.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(x => x.Number).IsRequired();
        builder.Property(x=>x.Name).IsRequired().HasColumnType("nvarchar(30)");
        builder.Property(x=>x.SurName).IsRequired().HasColumnType("nvarchar(30)");

        builder.HasOne(x=>x.Class).WithMany(x=>x.Students).HasForeignKey(x=>x.ClassId).OnDelete(DeleteBehavior.NoAction);
    }
}
