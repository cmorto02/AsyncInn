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
    public class HotelService : IHotelManager
    {
        private AsyncInnDBContext _context;

        public HotelService(AsyncInnDBContext context)
        {
            _context = context;
        }
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            Hotel hotel = await _context.Hotel.FirstOrDefaultAsync(h => h.ID == id);
            return hotel;
        }

        public async Task DeleteHotelConfirmation(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task EditHotel(int id, [Bind("ID,Name,StreetAdress,City,State,Phone")] Hotel hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }
            return hotel;
            
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotel.ToListAsync();
        }

        public bool HotelExists(int id)
        {
            return _context.Hotel.Any(h => h.ID == id);
        }
    }
}
