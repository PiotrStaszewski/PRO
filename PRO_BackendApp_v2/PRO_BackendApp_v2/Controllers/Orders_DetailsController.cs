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
    }
}