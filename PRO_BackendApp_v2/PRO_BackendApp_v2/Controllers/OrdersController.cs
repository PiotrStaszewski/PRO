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

        [HttpPost]
        public IActionResult Create(Zamowienie newOrder)
        {
            _context.Zamowienie.Add(newOrder);
            _context.SaveChanges();

            return StatusCode(201, newOrder);
        }

        [HttpPut("{IdZamowienie:int}")]
        public IActionResult Update(Zamowienie updatedOrder)
        {
            var c = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == updatedOrder.IdZamowienie);

            if (c == null)
            {
                return NotFound();
            }
            _context.Zamowienie.Attach(updatedOrder);
            _context.Entry(updatedOrder).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedOrder);
        }
        [HttpDelete("{IdZamowienie:int}")]
        public IActionResult Delete(int IdZamowienie)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);

            if (zamowienie == null)
            {
                return NotFound();
            }

            _context.Zamowienie.Remove(zamowienie);
            _context.SaveChanges();

            return Ok(zamowienie);
        }
    }
}