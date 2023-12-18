using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpWebApiEF.Models;

namespace EmpWebApiEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeptsController : ControllerBase
    {
        private readonly ActsDec2023Context _context;

        public DeptsController(ActsDec2023Context context)
        {
            _context = context;
        }

        // GET: api/Depts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dept>>> GetDepts()
        {
          if (_context.Depts == null)
          {
              return NotFound();
          }
            return await _context.Depts.ToListAsync();
        }

        // GET: api/Depts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dept>> GetDept(int id)
        {
          if (_context.Depts == null)
          {
              return NotFound();
          }
            var dept = await _context.Depts.FindAsync(id);

            if (dept == null)
            {
                return NotFound();
            }

            return dept;
        }

        // PUT: api/Depts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDept(int id, Dept dept)
        {
            if (id != dept.DeptNo)
            {
                return BadRequest();
            }

            _context.Entry(dept).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptExists(id))
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

        // POST: api/Depts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dept>> PostDept(Dept dept)
        {
          if (_context.Depts == null)
          {
              return Problem("Entity set 'ActsDec2023Context.Depts'  is null.");
          }
            _context.Depts.Add(dept);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeptExists(dept.DeptNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDept", new { id = dept.DeptNo }, dept);
        }

        // DELETE: api/Depts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            if (_context.Depts == null)
            {
                return NotFound();
            }
            var dept = await _context.Depts.FindAsync(id);
            if (dept == null)
            {
                return NotFound();
            }

            _context.Depts.Remove(dept);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptExists(int id)
        {
            return (_context.Depts?.Any(e => e.DeptNo == id)).GetValueOrDefault();
        }
    }
}
