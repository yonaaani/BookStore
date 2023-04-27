using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookListEntityFrameworkDataAccessLayer.Entities;

namespace BookListEntityFrameworkDataAccessLayer.EntityConfigurations
{
    public class EventDiscountsConfig : IEntityTypeConfiguration<EventDiscounts>
    {
        public void Configure(EntityTypeBuilder<EventDiscounts> builder)
        {
            builder
            .ToTable("EventDiscounts");

            builder
            .HasKey(ed => ed.IDDiscount);

            builder
                .HasOne(ed => ed.Event)
                .WithMany(e => e.EventDiscounts)
                .HasForeignKey(ed => ed.IDEvent);
        }
    }
}