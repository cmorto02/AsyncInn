using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
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

        public bool DeleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public void EditHotel(int id)
        {
            throw new NotImplementedException();
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
    }
}
