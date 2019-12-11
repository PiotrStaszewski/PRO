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
    }
}