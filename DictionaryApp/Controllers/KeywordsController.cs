using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DictionaryApp.Models;

namespace DictionaryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordsController : ControllerBase
    {
        private readonly stkContext _context;

        public KeywordsController(stkContext context)
        {
            _context = context;
        }

        // GET: api/Keywords
        public IEnumerable<Keywords> GetKeywords()
        {
            return _context.Keywords.ToList();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Keywords>>> GetKeywords()
        //{
        //    return await _context.Keywords.ToListAsync();
        //}

        // GET: api/Keywords/5
        [HttpGet("{id}")]
        public  List<Keywords> GetKeywords(string id)
        {
            List<Keywords> keywords = new List<Keywords>();
            keywords = _context.Keywords.Where(cus => cus.WordTr == id || cus.WordEn == id).ToList();

            return keywords;
        }

        // PUT: api/Keywords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKeywords(int id, Keywords keywords)
        {
            if (id != keywords.Id)
            {
                return BadRequest();
            }

            _context.Entry(keywords).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeywordsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Keywords
        [HttpPost]
        public async Task<ActionResult<Keywords>> PostKeywords(Keywords keywords)
        {
            _context.Keywords.Add(keywords);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKeywords", new { id = keywords.Id }, keywords);
        }

        // DELETE: api/Keywords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Keywords>> DeleteKeywords(int id)
        {
            var keywords = await _context.Keywords.FindAsync(id);
            if (keywords == null)
            {
                return NotFound();
            }

            _context.Keywords.Remove(keywords);
            await _context.SaveChangesAsync();

            return keywords;
        }

        private bool KeywordsExists(int id)
        {
            return _context.Keywords.Any(e => e.Id == id);
        }
    }
}
