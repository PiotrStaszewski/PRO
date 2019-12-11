using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}