using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Configurations;

public class MentorCourseConfiguration : IEntityTypeConfiguration<MentorCourse>
{
    public void Configure(EntityTypeBuilder<MentorCourse> builder)
    {
        builder.HasOne(x => x.Course)
            .WithMany(c => c.Mentors)
            .HasForeignKey(x => x.CourseId)
            .IsRequired();

        builder.HasOne(x => x.Mentor)
            .WithMany(m => m.Courses)
            .HasForeignKey(x => x.MentorId)
            .IsRequired();
    }
}
