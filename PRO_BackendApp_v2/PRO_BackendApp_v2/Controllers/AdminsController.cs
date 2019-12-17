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
    public class AdminsController : ControllerBase
    {
        private s16648Context _context;
        public AdminsController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getAdmins()
        {
            return Ok(_context.Admin.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getAdmin(int id)
        {
            var admin = _context.Admin.FirstOrDefault(e => e.IdAdmin == id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult Create(Admin newAdmin)
        {
            _context.Admin.Add(newAdmin);
            _context.SaveChanges();

            return StatusCode(201, newAdmin);
        }

        [HttpPut("{IdAdmin:int}")]
        public IActionResult Update(Admin updatedAdmin)
        {
            var c = _context.Admin.FirstOrDefault(e => e.IdAdmin== updatedAdmin.IdAdmin);

            if (c == null)
            {
                return NotFound();
            }
            _context.Admin.Attach(updatedAdmin);
            _context.Entry(updatedAdmin).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedAdmin);
        }
        [HttpDelete("{IdAdmin:int}")]
        public IActionResult Delete(int IdAdmin)
        {
            var admin = _context.Admin.FirstOrDefault(e => e.IdAdmin == IdAdmin);

            if (admin == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(admin);
            _context.SaveChanges();

            return Ok(admin);
        }
    }
}