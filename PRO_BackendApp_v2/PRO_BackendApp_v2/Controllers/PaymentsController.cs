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
    public class PaymentsController : ControllerBase
    {
        private s16648Context _context;

        public PaymentsController(s16648Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getPayments()
        {
            return Ok(_context.Platnosc.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult getPayment(int id)
        {
            var payment = _context.Platnosc.FirstOrDefault(e => e.IdPlatnosc == id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpPost]
        public IActionResult Create(Platnosc newPayment)
        {
            _context.Platnosc.Add(newPayment);
            _context.SaveChanges();

            return StatusCode(201, newPayment);
        }

        [HttpPut("{IdPlatnosc:int}")]
        public IActionResult Update(Platnosc updatedPayment)
        {
            var c = _context.Platnosc.FirstOrDefault(e => e.IdPlatnosc == updatedPayment.IdPlatnosc);

            if (c == null)
            {
                return NotFound();
            }
            _context.Platnosc.Attach(updatedPayment);
            _context.Entry(updatedPayment).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPayment);
        }
        [HttpDelete("{IdPlatnosc:int}")]
        public IActionResult Delete(int IdPlatnosc)
        {
            var platnosc = _context.Platnosc.FirstOrDefault(e => e.IdPlatnosc == IdPlatnosc);

            if (platnosc == null)
            {
                return NotFound();
            }

            _context.Platnosc.Remove(platnosc);
            _context.SaveChanges();

            return Ok(platnosc);
        }
    }
}