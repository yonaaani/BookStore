using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookListEntityFrameworkDataAccessLayer.Entities;

namespace BookListEntityFrameworkDataAccessLayer.EntityConfigurations
{
    public class EventOthersConfig : IEntityTypeConfiguration<EventOthers>
    {
        public void Configure(EntityTypeBuilder<EventOthers> builder)
        {
            builder
            .HasKey(eo => eo.IDOther);

            builder
            .Property(eo => eo.OtherName)
            .HasMaxLength(25);

            builder
                .Property(eo => eo.Discription)
                .HasMaxLength(255);

            builder
                .HasOne(eo => eo.Event)
                .WithMany(e => e.EventOthers)
                .HasForeignKey(eo => eo.IDEvent);
        }
    }
}