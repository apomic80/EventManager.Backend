namespace EventManager.Business.Data.EF
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class EventManagerDbContext
        : DbContext
    {
        public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<AgendaItem> Agenda { get; set; }


    }
}
