using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameforkDAL;
using MyBookListEntityFrameforkDAL.Entities;
using MyBookListEntityFrameworkDAL.EntityConfiguration;


namespace MyBookListEntityFrameworkDAL.EntityConfiguration
{
    public class EventsContext : DbContext
    {
        public DbSet<Events> Events { get; set; }
        public DbSet<EventDiscounts> EventsDiscounts { get; set; }
        public DbSet<EventFilms> EventFilms { get; set; }
        public DbSet<EventNewBooks> EventNewBooks { get; set; }
        public DbSet<EventOthers> EventOthers { get; set; }

        public  EventsContext()
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
            modelBuilder.ApplyConfiguration(new EventsConfig());
        }
    }


}