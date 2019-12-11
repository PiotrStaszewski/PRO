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
    public class OrdersController : ControllerBase
    {
        private s16648Context _context;
        public OrdersController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getOrders()
        {
            return Ok(_context.Zamowienie.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getOrder(int id)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}