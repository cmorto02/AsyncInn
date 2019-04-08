using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        public ICollection<HotelRoom> HotelRooms { get; set; }
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        Studio,
        TwoBed,
        ThreeBed
    }
}
