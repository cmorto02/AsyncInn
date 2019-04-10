using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDBContext : DbContext
    {
        public AsyncInnDBContext(DbContextOptions<AsyncInnDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(ck => new { ck.HotelID, ck.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(ck => new { ck.RoomID, ck.AmenitiesID });
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
