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
    }
}