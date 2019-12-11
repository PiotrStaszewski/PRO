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
        [HttpPost]
        public IActionResult Create(Klient newClient)
        {
            _context.Klient.Add(newClient);
            _context.SaveChanges();

            return StatusCode(201, newClient);
        }

        [HttpPut("{IdKlienta:int}")]
        public IActionResult Update(Klient updatedClient)
        {
            var c = _context.Klient.FirstOrDefault(e => e.IdKlienta == updatedClient.IdKlienta);

            if (c == null)
            {
                return NotFound();
            }
            _context.Klient.Attach(updatedClient);
            _context.Entry(updatedClient).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedClient);
        }
        [HttpDelete("{IdKlienta:int}")]
        public IActionResult Delete(int IdKlienta)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.IdKlienta == IdKlienta);

            if (klient == null)
            {
                return NotFound();
            }

            _context.Klient.Remove(klient);
            _context.SaveChanges();

            return Ok(klient);
        }
    }
}