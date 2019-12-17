using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRO_BackendApp_v2.Models;

namespace PRO_BackendApp_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private s16648Context _context;
        public PlacesController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getPlaces()
        {
            return Ok(_context.Lokal.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getPlace(int id)
        {
            var place = _context.Lokal.FirstOrDefault(e => e.IdLokalu == id);
            if (place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }

        [HttpPost]
        public IActionResult Create(Lokal newPlace)
        {
            _context.Lokal.Add(newPlace);
            _context.SaveChanges();

            return StatusCode(201, newPlace);
        }

        [HttpPut("{IdLokal:int}")]
        public IActionResult Update(Lokal updatedPlace)
        {
            var c = _context.Lokal.FirstOrDefault(e => e.IdLokalu == updatedPlace.IdLokalu);

            if (c == null)
            {
                return NotFound();
            }
            _context.Lokal.Attach(updatedPlace);
            _context.Entry(updatedPlace).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPlace);
        }
        [HttpDelete("{IdLokal:int}")]
        public IActionResult Delete(int IdLokal)
        {
            var lokal = _context.Lokal.FirstOrDefault(e => e.IdLokalu == IdLokal);

            if (lokal == null)
            {
                return NotFound();
            }

            _context.Lokal.Remove(lokal);
            _context.SaveChanges();

            return Ok(lokal);
        }
    }
}