using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookListEntityFrameforkDAL.Entities;

namespace MyBookListEntityFrameworkDAL.EntityConfiguration
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


        }
    }
}