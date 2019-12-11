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
    public class ProductsController : ControllerBase
    {
        private s16648Context _context;
        public ProductsController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getProducts()
        {
            return Ok(_context.Produkt.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getProduct(int id)
        {
            var product = _context.Produkt.FirstOrDefault(e => e.IdProduktu == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}