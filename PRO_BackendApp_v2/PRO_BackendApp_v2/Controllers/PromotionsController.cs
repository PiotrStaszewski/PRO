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
    }
}