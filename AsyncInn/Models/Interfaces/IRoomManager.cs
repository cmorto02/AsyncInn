using AsyncInn.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        //Create a room
        Task CreateRoom(Room room);

        //Edit a room
        Task EditRoom(int id, [Bind("ID,Name,Layout")] Room room);

        //View a single room
        Task<Room> GetRoom(int id);

        //View all room
        Task<List<Room>> GetRooms();

        //Delete room
        Task<Room> DeleteRoom(int id);

        //The room exists
        bool RoomExists(int id);

        //Delete confirmaiton
        Task DeleteRoomConfirmation(int id);
    }
}
