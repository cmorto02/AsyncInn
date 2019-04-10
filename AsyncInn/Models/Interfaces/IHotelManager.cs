using AsyncInn.Data;
using Microsoft.AspNetCore.Mvc;
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
        Task EditHotel(int id, [Bind("ID,Name,StreetAdress,City,State,Phone")] Hotel hotel);

        //View a single hotel
        Task<Hotel> GetHotel(int id);

        //View all hotels
        Task<List<Hotel>> GetHotels();

        //Delete hotels
        Task<Hotel> DeleteHotel(int id);

        bool HotelExists(int id);

        Task DeleteHotelConfirmation(int id);

    }
}
