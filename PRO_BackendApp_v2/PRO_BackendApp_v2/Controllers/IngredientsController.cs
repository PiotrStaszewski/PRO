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
    public class IngredientsController : ControllerBase
    {
        private s16648Context _context;

        public IngredientsController(s16648Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getIngerdients()
        {
            return Ok(_context.Skladnik.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult getIngredient(int id)
        {
            var ingredient = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }
    }
}