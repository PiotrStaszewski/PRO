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
    public class AddressesController : ControllerBase
    {
        private s16648Context _context;
        public AddressesController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getAddresses()
        {
            return Ok(_context.Adres.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getAddress(int id)
        {
            var address = _context.Adres.FirstOrDefault(e => e.IdAdres == id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        public IActionResult Create(Adres newAdres)
        {
            _context.Adres.Add(newAdres);
            _context.SaveChanges();

            return StatusCode(201, newAdres);
        }

        [HttpPut("{IdAdres:int}")]
        public IActionResult Update(Adres updatedAddress)
        {
            var c = _context.Adres.FirstOrDefault(e => e.IdAdres == updatedAddress.IdAdres);

            if (c == null)
            {
                return NotFound();
            }
            _context.Adres.Attach(updatedAddress);
            _context.Entry(updatedAddress).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedAddress);
        }
        [HttpDelete("{IdAdres:int}")]
        public IActionResult Delete(int IdAdres)
        {
            var adres = _context.Adres.FirstOrDefault(e => e.IdAdres == IdAdres);

            if (adres == null)
            {
                return NotFound();
            }

            _context.Adres.Remove(adres);
            _context.SaveChanges();

            return Ok(adres);
        }
    }
}