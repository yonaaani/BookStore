using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookListEntityFrameworkDataAccessLayer.Entities;
using System.Data.Entity.ModelConfiguration;

namespace BookListEntityFrameworkDataAccessLayer.EntityConfigurations
{
    public class EventsConfig : IEntityTypeConfiguration<Events>
    {
        public void Configure(EntityTypeBuilder<Events> builder)
        {
            builder.HasKey(e => e.IDEvent);
            builder.Property(e => e.EventName)
           .IsRequired()
           .IsUnicode(false);

            builder.Property(e => e.EventText)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}