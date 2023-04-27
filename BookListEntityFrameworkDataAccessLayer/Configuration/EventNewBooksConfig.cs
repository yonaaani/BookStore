using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookListEntityFrameworkDataAccessLayer.Entities;

namespace BookListEntityFrameworkDataAccessLayer.EntityConfigurations
{
    public class EventNewBooksConfig : IEntityTypeConfiguration<EventNewBooks>
    {
        public void Configure(EntityTypeBuilder<EventNewBooks> builder)
        {
            builder
            .HasKey(eb => eb.IDNewBook);

            builder
              .Property(eb => eb.BookName)
              .HasMaxLength(25);

            builder
                .Property(eb => eb.Author)
                .HasMaxLength(25);

            builder
                .Property(eb => eb.Information)
                .HasMaxLength(255);

            builder
                .HasOne(eb => eb.Event)
                .WithMany(e => e.EventNewBooks)
                .HasForeignKey(eb => eb.IDEvent);
        }
    }
}