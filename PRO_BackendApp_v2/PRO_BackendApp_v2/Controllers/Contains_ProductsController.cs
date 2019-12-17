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

        [HttpPost]
        public IActionResult Create(ZawieraProdukty newContainsProducts)
        {
            _context.ZawieraProdukty.Add(newContainsProducts);
            _context.SaveChanges();

            return StatusCode(201, newContainsProducts);
        }

        [HttpPut("{IdZawieraProdukty:int}")]
        public IActionResult Update(ZawieraProdukty updatedContainsProducts)
        {
            var c = _context.ZawieraProdukty.FirstOrDefault(e => e.IdZawiera == updatedContainsProducts.IdZawiera);

            if (c == null)
            {
                return NotFound();
            }
            _context.ZawieraProdukty.Attach(updatedContainsProducts);
            _context.Entry(updatedContainsProducts).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedContainsProducts);
        }
        [HttpDelete("{IdZawieraProdukty:int}")]
        public IActionResult Delete(int IdZawiera)
        {
            var zawieraProdukty = _context.ZawieraProdukty.FirstOrDefault(e => e.IdZawiera == IdZawiera);

            if (zawieraProdukty == null)
            {
                return NotFound();
            }

            _context.ZawieraProdukty.Remove(zawieraProdukty);
            _context.SaveChanges();

            return Ok(zawieraProdukty);
        }
    }
}