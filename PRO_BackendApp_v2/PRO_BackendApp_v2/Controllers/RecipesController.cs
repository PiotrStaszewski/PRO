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
    public class RecipesController : ControllerBase
    {
        public s16648Context _context;
        public RecipesController(s16648Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getRecipes()
        {
            return Ok(_context.Przepis.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult getRecipe(int id)
        {
            var recipe = _context.Przepis.FirstOrDefault(e => e.IdPrzepisu == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }
    }
}