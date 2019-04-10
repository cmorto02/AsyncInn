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
        public async Task<IActionResult> Index()
        {
            List<Hotel> myHotels = await _hotels.GetHotels();
            return View(myHotels);
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

        #region CRUD

        //// GET: Hotels/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Hotels/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Name,StreetAddress,City,State,Phone")] Hotel hotel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _hotels.Add(hotel);
        //        await _hotels.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hotel);
        //}

        //// GET: Hotels/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hotel = await _hotels.Hotels.FindAsync(id);
        //    if (hotel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(hotel);
        //}

        //// POST: Hotels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,Name,StreetAddress,City,State,Phone")] Hotel hotel)
        //{
        //    if (id != hotel.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _hotels.Update(hotel);
        //            await _hotels.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HotelExists(hotel.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(hotel);
        //}

        //// GET: Hotels/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var hotel = await _hotels.Hotels
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (hotel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(hotel);
        //}

        //// POST: Hotels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var hotel = await _hotels.Hotels.FindAsync(id);
        //    _hotels.Hotels.Remove(hotel);
        //    await _hotels.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool HotelExists(int id)
        //{
        //    return _hotels.Hotels.Any(e => e.ID == id);
        //}

        #endregion
    }
}
