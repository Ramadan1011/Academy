using Academy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasMany(x => x.Mentors)
                    .WithOne(x => x.Course)
                    .HasForeignKey(x => x.CourseId)
                    .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(DefaultConfiguration.DefaultStringLength)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(DefaultConfiguration.MaxStringLength)
            .IsRequired(false);
        builder.Property(x => x.Price)
            .HasColumnType("money")
            .HasPrecision(13, 2)
            .IsRequired();
        builder.Property(x => x.Discount)
            .HasColumnType("money")
            .HasPrecision(13, 2)
            .IsRequired();
    }
}
