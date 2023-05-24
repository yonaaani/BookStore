using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookListEntityFrameforkDAL.Entities;

namespace MyBookListEntityFrameworkDAL.EntityConfiguration
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
                .Property(eo => eo.Description)
                .HasMaxLength(255);

        }
    }
}