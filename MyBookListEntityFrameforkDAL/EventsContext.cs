using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameforkDAL;
using MyBookListEntityFrameforkDAL.Entities;
using MyBookListEntityFrameforkDAL.EntityConfiguration;
using MyBookListEntityFrameworkDAL.EntityConfiguration;


namespace MyBookListEntityFrameworkDAL
{
    public class EventsContext : DbContext
    {
        public DbSet<Events> Events { get; set; }
        public DbSet<EventDiscounts> EventsDiscounts { get; set; }
        public DbSet<EventFilms> EventFilms { get; set; }
        public DbSet<EventNewBooks> EventNewBooks { get; set; }
        public DbSet<EventOthers> EventOthers { get; set; }

        public EventsContext()
        {

        }
        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>().ToTable("Events");
            modelBuilder.ApplyConfiguration(new EventsConfig());

            modelBuilder.Entity<EventOthers>().ToTable("EventOthers");
            modelBuilder.ApplyConfiguration(new EventOthersConfig());

            modelBuilder.Entity<EventNewBooks>().ToTable("EventNewBooks");
            modelBuilder.ApplyConfiguration(new EventNewBooksConfig());

            modelBuilder.Entity<EventFilms>().ToTable("EventFilms");
            modelBuilder.ApplyConfiguration(new EventFilmsConfig());

            modelBuilder.Entity<EventDiscounts>().ToTable("EventDiscounts");
            modelBuilder.ApplyConfiguration(new EventDiscountsConfig());
        }
    }


}