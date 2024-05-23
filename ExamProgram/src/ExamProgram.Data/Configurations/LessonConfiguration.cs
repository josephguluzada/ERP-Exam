using ExamProgram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProgram.Data.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.Property(x => x.Code).IsRequired().HasColumnType("varchar(3)");
        builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(30)");

        builder.HasOne(x => x.Teacher).WithMany(x => x.Lessons).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.NoAction);
    }
}
