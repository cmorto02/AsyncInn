using AsyncInn.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenitiesManager
    {
        //Create an amenity
        Task CreateAmenity(Amenities amenity);

        //Edit a hotel
        Task EditAmenity(int id, [Bind("ID,Name")] Amenities amenity);

        //View a single hotel
        Task<Amenities> GetAmenity(int id);

        //View all hotels
        Task<List<Amenities>> GetAmenities();

        //Delete hotels
        Task<Amenities> DeleteAmenity(int id);

        //The amenity exists
        bool AmenityExists(int id);

        //Delete confirmation
        Task DeleteAmenityConfirmation(int id);
    }
}
