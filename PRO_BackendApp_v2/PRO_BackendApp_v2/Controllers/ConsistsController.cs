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
    public class ConsistsController : ControllerBase
    {
        private s16648Context _context;
        public ConsistsController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getConsists()
        {
            return Ok(_context.SkladaSie.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getConsist(int id)
        {
            var consist = _context.SkladaSie.FirstOrDefault(e => e.IdSkladaSie == id);
            if (consist == null)
            {
                return NotFound();
            }
            return Ok(consist);
        }
    }
}