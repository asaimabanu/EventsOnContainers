using EventsCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsCatalogAPI.Data
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EventCategory> EventCategories { get; set; }
        
        public DbSet<EventItem> EventItems { get; set; }
        
        public DbSet<EventLocation> EventLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<EventLocation>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(300);

                e.Property(t => t.Price)
                .IsRequired();

                e.Property(t => t.EventStartDateTime)
                .IsRequired();

                //e.Property(t => t.EventEndDateTime) 
                //.IsRequired();

                e.Property(t => t.IsOnlineEvent) 
                .IsRequired();

                e.HasOne(t => t.EventCategory)
                .WithMany()
                .HasForeignKey(t => t.EventCategoryId);

                e.HasOne(t => t.EventLocation) 
                .WithMany() 
                .HasForeignKey(t =>t.EventLocationId);
            });

        }
    }
}
