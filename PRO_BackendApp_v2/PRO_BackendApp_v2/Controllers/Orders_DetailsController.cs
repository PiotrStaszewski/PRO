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
    public class Orders_DetailsController : ControllerBase
    {
        private s16648Context _context;
        public Orders_DetailsController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getOrdersDetails()
        {
            return Ok(_context.ZamowienieSzczegoly.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getOrderDetails(int id)
        {
            var orderDetails = _context.ZamowienieSzczegoly.FirstOrDefault(e => e.IdSzczegoly == id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }

        [HttpPost]
        public IActionResult Create(ZamowienieSzczegoly newOrderDetails)
        {
            _context.ZamowienieSzczegoly.Add(newOrderDetails);
            _context.SaveChanges();

            return StatusCode(201, newOrderDetails);
        }

        [HttpPut("{IdZamowienieSzczegoly:int}")]
        public IActionResult Update(ZamowienieSzczegoly updatedOrderDetails)
        {
            var c = _context.ZamowienieSzczegoly.FirstOrDefault(e => e.IdSzczegoly == updatedOrderDetails.IdSzczegoly);

            if (c == null)
            {
                return NotFound();
            }
            _context.ZamowienieSzczegoly.Attach(updatedOrderDetails);
            _context.Entry(updatedOrderDetails).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedOrderDetails);
        }
        [HttpDelete("{IdZamowienieSzczegoly:int}")]
        public IActionResult Delete(int IdZamowienieSzczegoly)
        {
            var zamowienieSzczegoly = _context.ZamowienieSzczegoly.FirstOrDefault(e => e.IdSzczegoly == IdZamowienieSzczegoly);

            if (zamowienieSzczegoly == null)
            {
                return NotFound();
            }

            _context.ZamowienieSzczegoly.Remove(zamowienieSzczegoly);
            _context.SaveChanges();

            return Ok(zamowienieSzczegoly);
        }
    }
}