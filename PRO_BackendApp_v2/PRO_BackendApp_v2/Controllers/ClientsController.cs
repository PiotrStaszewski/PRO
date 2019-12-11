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
    public class ClientsController : ControllerBase
    {
        private s16648Context _context;
        public ClientsController(s16648Context context)
        {
            _context = context;
        }
        //api/restaurant
        [HttpGet]
        public IActionResult getClients()
        {
            return Ok(_context.Klient.ToList());
        }
        //api/restaurant/1
        [HttpGet("{id:int}")]
        public IActionResult getClient(int id)
        {
            var client = _context.Klient.FirstOrDefault(e => e.IdKlienta == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}