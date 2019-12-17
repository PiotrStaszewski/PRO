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

        [HttpPost]
        public IActionResult Create(SkladaSie newConsists)
        {
            _context.SkladaSie.Add(newConsists);
            _context.SaveChanges();

            return StatusCode(201, newConsists);
        }

        [HttpPut("{IdSkladaSie:int}")]
        public IActionResult Update(SkladaSie updatedConsists)
        {
            var c = _context.SkladaSie.FirstOrDefault(e => e.IdSkladaSie == updatedConsists.IdSkladaSie);

            if (c == null)
            {
                return NotFound();
            }
            _context.SkladaSie.Attach(updatedConsists);
            _context.Entry(updatedConsists).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedConsists);
        }
        [HttpDelete("{IdSkladaSie:int}")]
        public IActionResult Delete(int IdSkladaSie)
        {
            var skladaSie = _context.SkladaSie.FirstOrDefault(e => e.IdSkladaSie == IdSkladaSie);

            if (skladaSie == null)
            {
                return NotFound();
            }

            _context.SkladaSie.Remove(skladaSie);
            _context.SaveChanges();

            return Ok(skladaSie);
        }
    }
}