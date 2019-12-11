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
    }
}