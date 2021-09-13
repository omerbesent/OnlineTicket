using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Entities.Concrete;
using System;
using System.IO;

namespace OnlineTicket.DataAccess.Concrete.EntityFramework
{
    public class OnlineTicketContext : DbContext
    {
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceSeatingPlan> PlaceSeatingPlans { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<EventSelectedSeat> EventSelectedSeats { get; set; }
        public DbSet<Poster> Posters { get; set; }
        public DbSet<UserSelectedSeat> UserSelectedSeats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            JToken jAppSettings = JToken.Parse(
                File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
            string connectionString = jAppSettings["ConnectionStrings"]["DefaultConnection"].ToString();

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                .HasOne<City>(e => e.City)
                .WithMany(d => d.Places)
                .HasForeignKey(e => e.CityId);

            modelBuilder.Entity<Place>()
                .HasOne<County>(e => e.County)
                .WithMany(d => d.Places)
                .HasForeignKey(e => e.CountyId);

            modelBuilder.Entity<Event>()
                .HasOne<Category>(e => e.Category)
                .WithMany(d => d.Events)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Event>()
                .HasOne<Place>(e => e.Place)
                .WithMany(d => d.Events)
                .HasForeignKey(e => e.PlaceId);

            modelBuilder.Entity<Session>()
                .HasOne<Event>(e => e.Event)
                .WithMany(d => d.Sessions)
                .HasForeignKey(e => e.EventId);

            modelBuilder.Entity<EventSelectedSeat>()
                .HasOne<Event>(e => e.Event)
                .WithMany(d => d.EventSelectedSeats)
                .HasForeignKey(e => e.EventId);

        }

    }
}
