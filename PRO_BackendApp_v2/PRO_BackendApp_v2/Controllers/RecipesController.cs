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

        [HttpPost]
        public IActionResult Create(Przepis newRecipe)
        {
            _context.Przepis.Add(newRecipe);
            _context.SaveChanges();

            return StatusCode(201, newRecipe);
        }

        [HttpPut("{IdPrzepis:int}")]
        public IActionResult Update(Przepis updatedRecipe)
        {
            var c = _context.Przepis.FirstOrDefault(e => e.IdPrzepisu == updatedRecipe.IdPrzepisu);

            if (c == null)
            {
                return NotFound();
            }
            _context.Przepis.Attach(updatedRecipe);
            _context.Entry(updatedRecipe).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedRecipe);
        }
        [HttpDelete("{IdPrzepis:int}")]
        public IActionResult Delete(int IdPrzepis)
        {
            var przepis = _context.Przepis.FirstOrDefault(e => e.IdPrzepisu == IdPrzepis);

            if (przepis == null)
            {
                return NotFound();
            }

            _context.Przepis.Remove(przepis);
            _context.SaveChanges();

            return Ok(przepis);
        }
    }
}