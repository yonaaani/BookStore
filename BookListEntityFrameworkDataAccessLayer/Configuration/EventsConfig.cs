using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookListEntityFrameworkDataAccessLayer.Entities;

namespace BookListEntityFrameworkDataAccessLayer.EntityConfiguration
{
    public class EventsConfig : IEntityTypeConfiguration<Events>
    {
        public void Configure(EntityTypeBuilder<Events> builder)
        {
            builder.HasKey(e => e.IDEvent);

            builder.Property(e => e.EventName)
                 .HasMaxLength(25);

            builder.Property(e => e.EventDate)
                   .IsRequired(true)
                .HasColumnType("DateTime");

            builder.Property(e => e.EventText)
                .HasMaxLength(255);

        }
    }
}
