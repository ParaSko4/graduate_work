using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using graduate_work.Databases.MySQL;
using graduate_work.Models;

namespace graduate_work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolAdminsController : ControllerBase
    {
        private readonly MySQLContext _context;

        public SchoolAdminsController(MySQLContext context)
        {
            _context = context;
        }

        //// GET: api/SchoolAdmins
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserAccount>>> GetSchoolAdmins()
        //{
        //    return await _context.SchoolAdmins.ToListAsync();
        //}

        //// GET: api/SchoolAdmins/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserAccount>> GetSchoolAdmin(int id)
        //{
        //    var schoolAdmin = await _context.SchoolAdmins.FindAsync(id);

        //    if (schoolAdmin == null)
        //    {
        //        return NotFound();
        //    }

        //    return schoolAdmin;
        //}

        //// PUT: api/SchoolAdmins/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSchoolAdmin(int id, UserAccount schoolAdmin)
        //{
        //    if (id != schoolAdmin.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(schoolAdmin).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SchoolAdminExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/SchoolAdmins
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserAccount>> PostSchoolAdmin(UserAccount schoolAdmin)
        //{
        //    _context.SchoolAdmins.Add(schoolAdmin);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSchoolAdmin", new { id = schoolAdmin.Id }, schoolAdmin);
        //}

        //// DELETE: api/SchoolAdmins/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSchoolAdmin(int id)
        //{
        //    var schoolAdmin = await _context.SchoolAdmins.FindAsync(id);
        //    if (schoolAdmin == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.SchoolAdmins.Remove(schoolAdmin);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SchoolAdminExists(int id)
        //{
        //    return _context.SchoolAdmins.Any(e => e.Id == id);
        //}
    }
}
