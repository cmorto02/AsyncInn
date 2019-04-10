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
    public class RoomService : IRoomManager
    {
        private AsyncInnDBContext _context;

        public RoomService(AsyncInnDBContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> DeleteRoom(int id)
        {
            Room room = await _context.Rooms.FirstOrDefaultAsync(r => r.ID == id);
            return room;
        }

        public async Task DeleteRoomConfirmation(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task EditRoom(int id, [Bind("ID,Name,Layout")] Room room)
        {
            _context.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public bool RoomExists(int id)
        {
            return _context.Rooms.Any(r => r.ID == id);
        }
    }
}
