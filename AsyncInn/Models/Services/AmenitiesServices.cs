using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenitiesServices : IAmenitiesManager
    {
        private AsyncInnDBContext _context;

        public AmenitiesServices(AsyncInnDBContext context)
        {
            _context = context;
        }

        public bool AmenityExists(int id)
        {
            return _context.Amenities.Any(a => a.ID == id);
        }

        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> DeleteAmenity(int id)
        {
            Amenities amenity = await _context.Amenities.FirstOrDefaultAsync(a => a.ID == id);
            return amenity;
        }

        public async Task DeleteAmenityConfirmation(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task EditAmenity(int id, [Bind(new[] { "ID,Name" })] Amenities amenity)
        {
            _context.Update(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenities> GetAmenity(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return null;
            }
            return amenity;
        }

        public async Task<List<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }
    }
}
