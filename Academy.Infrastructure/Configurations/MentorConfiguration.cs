using Academy.Domain.Entities;
using Academy.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academy.Infrastructure.Configurations;

public class MentorConfiguration : IEntityTypeConfiguration<Mentor>
{
    public void Configure(EntityTypeBuilder<Mentor> builder)
    {
        builder.HasMany(x => x.Courses)
                    .WithOne(c => c.Mentor)
                    .HasForeignKey(c => c.MentorId)
                    .IsRequired();

        builder.Property(x => x.FirstName)
            .HasMaxLength(DefaultConfiguration.DefaultStringLength)
            .IsRequired();
        builder.Property(x => x.LastName)
            .HasMaxLength(DefaultConfiguration.DefaultStringLength)
            .IsRequired();
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(DefaultConfiguration.PhoneNumberLength)
            .IsRequired();
        builder.Property(x => x.Degree)
            .HasDefaultValue(Degree.Bachelor)
            .IsRequired();
    }
}
