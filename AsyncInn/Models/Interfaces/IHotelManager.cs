using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        //Create a hotel
        Task CreateHotel(Hotel hotel);

        //Edit a hotel
        void EditHotel(int id);

        //View a single hotel
        Task<Hotel> GetHotel(int id);

        //View all hotels
        Task<List<Hotel>> GetHotels();

        //Delete hotels
        bool DeleteHotel(int id);

    }
}
