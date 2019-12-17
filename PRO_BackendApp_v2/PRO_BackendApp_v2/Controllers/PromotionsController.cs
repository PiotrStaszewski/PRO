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
    public class PromotionsController : ControllerBase
    {
        public s16648Context _context;
        public PromotionsController(s16648Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getPromotions()
        {
            return Ok(_context.Promocja.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult getPromotion(int id)
        {
            var promotion = _context.Promocja.FirstOrDefault(e => e.IdPromocji == id);
            if (promotion == null)
            {
                return NotFound();
            }
            return Ok(promotion);
        }

        [HttpPost]
        public IActionResult Create(Promocja newPromotion)
        {
            _context.Promocja.Add(newPromotion);
            _context.SaveChanges();

            return StatusCode(201, newPromotion);
        }

        [HttpPut("{IdPromotion:int}")]
        public IActionResult Update(Promocja updatedPromotion)
        {
            var c = _context.Promocja.FirstOrDefault(e => e.IdPromocji == updatedPromotion.IdPromocji);

            if (c == null)
            {
                return NotFound();
            }
            _context.Promocja.Attach(updatedPromotion);
            _context.Entry(updatedPromotion).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPromotion);
        }
        [HttpDelete("{IdPromocja:int}")]
        public IActionResult Delete(int IdPromocja)
        {
            var promocja = _context.Promocja.FirstOrDefault(e => e.IdPromocji == IdPromocja);

            if (promocja == null)
            {
                return NotFound();
            }

            _context.Promocja.Remove(promocja);
            _context.SaveChanges();

            return Ok(promocja);
        }
    }
}