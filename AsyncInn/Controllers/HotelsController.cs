using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;

namespace AsyncInn.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelManager _hotels;

        public HotelsController(IHotelManager hotels)
        {
            _hotels = hotels;
        }

        // GET: Hotels
        public async Task<IActionResult> Index(string searchString)
        {
            var hotelselect = from h in await _hotels.GetHotels()
                         select h;

            if (!String.IsNullOrEmpty(searchString))
            {
                hotelselect = hotelselect.Where(s => s.Name.Contains(searchString));
            }
            List<Hotel> myHotels = await _hotels.GetHotels();
            return View(hotelselect);
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var hotel = await _hotels.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,StreetAddress,City,State,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _hotels.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        //// GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var hotel = await _hotels.GetHotel(id);
            return View(hotel);
        }

        //// POST: Hotels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StreetAddress,City,State,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotels.EditHotel(id, hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        //// GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Hotel hotel = await _hotels.DeleteHotel(id);

            return View(hotel);
        }

        //// POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _hotels.DeleteHotelConfirmation(id);
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _hotels.HotelExists(id);
        }
    }
}
