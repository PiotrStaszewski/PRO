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

        [HttpPost]
        public IActionResult Create(Produkt newProduct)
        {
            _context.Produkt.Add(newProduct);
            _context.SaveChanges();

            return StatusCode(201, newProduct);
        }

        [HttpPut("{IdProdukt:int}")]
        public IActionResult Update(Produkt updatedProduct)
        {
            var c = _context.Produkt.FirstOrDefault(e => e.IdProduktu == updatedProduct.IdProduktu);

            if (c == null)
            {
                return NotFound();
            }
            _context.Produkt.Attach(updatedProduct);
            _context.Entry(updatedProduct).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedProduct);
        }
        [HttpDelete("{IdProdukt:int}")]
        public IActionResult Delete(int IdProduktu)
        {
            var produkt = _context.Produkt.FirstOrDefault(e => e.IdProduktu == IdProduktu);

            if (produkt == null)
            {
                return NotFound();
            }

            _context.Produkt.Remove(produkt);
            _context.SaveChanges();

            return Ok(produkt);
        }
    }
}