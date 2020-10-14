using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSoftware.Server.Data;
using BookingSoftware.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSoftware.Server.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookingContext _context;
        public BookController(BookingContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Books.ToListAsync();
            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Books.FirstOrDefaultAsync(a=>a.BookId == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book developer)
        {
            _context.Add(developer);
            await _context.SaveChangesAsync();
            return Ok(developer.BookId); 
        }

        [HttpPut]
        public async Task<IActionResult> Put(Book developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new Book { BookId = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
