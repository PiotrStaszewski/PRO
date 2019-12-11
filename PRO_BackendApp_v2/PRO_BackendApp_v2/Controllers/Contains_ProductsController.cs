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
    public class Contains_ProductsController : ControllerBase
    {
        private s16648Context _context;
        public Contains_ProductsController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getContainsProducts()
        {
            return Ok(_context.ZawieraProdukty.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getContainsProduct(int id)
        {
            var containsProducts = _context.ZawieraProdukty.FirstOrDefault(e => e.IdZawiera == id);
            if (containsProducts == null)
            {
                return NotFound();
            }
            return Ok(containsProducts);
        }
    }
}