using ExamProgram.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamProgram.Data.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.Property(x=>x.ExamDate).IsRequired().HasColumnType("date");
        builder.Property(x => x.Grade).IsRequired();

        builder.HasOne(x=>x.Student).WithMany(x=>x.Exams).HasForeignKey(x=>x.StudentId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x=>x.Lesson).WithMany(x=>x.Exams).HasForeignKey(x=>x.LessonId).OnDelete(DeleteBehavior.NoAction);

    }
}
