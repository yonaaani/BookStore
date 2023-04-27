using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookListEntityFrameworkDataAccessLayer.Entities;

namespace BookListEntityFrameworkDataAccessLayer.EntityConfigurations
{
    public class EventFilmsConfig : IEntityTypeConfiguration<EventFilms>
    {
        public void Configure(EntityTypeBuilder<EventFilms> builder)
        {
            builder
            .HasKey(ef => ef.IDFilm);

            builder
            .Property(ef => ef.FilmName)
            .HasMaxLength(25);

            builder
                .Property(ef => ef.Information)
                .HasMaxLength(255);

            builder
                .HasOne(ef => ef.Event)
                .WithMany(e => e.EventFilms)
                .HasForeignKey(ef => ef.IDEvent);
        }
    }
}