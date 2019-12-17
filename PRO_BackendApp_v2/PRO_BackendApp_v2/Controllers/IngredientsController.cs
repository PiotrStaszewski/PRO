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

        [HttpPost]
        public IActionResult Create(Skladnik newIngredient)
        {
            _context.Skladnik.Add(newIngredient);
            _context.SaveChanges();

            return StatusCode(201, newIngredient);
        }

        [HttpPut("{IdSkladnik:int}")]
        public IActionResult Update(Skladnik updatedIngredient)
        {
            var c = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == updatedIngredient.IdSkladnik);

            if (c == null)
            {
                return NotFound();
            }
            _context.Skladnik.Attach(updatedIngredient);
            _context.Entry(updatedIngredient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedIngredient);
        }
        [HttpDelete("{IdSkladnik:int}")]
        public IActionResult Delete(int IdSkladnik)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(e => e.IdSkladnik == IdSkladnik);

            if (skladnik == null)
            {
                return NotFound();
            }

            _context.Skladnik.Remove(skladnik);
            _context.SaveChanges();

            return Ok(skladnik);
        }
    }
}