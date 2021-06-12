using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doctors.Database;
using Doctors.Models;

namespace Doctors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorModelsController : ControllerBase
    {
        private readonly DContext _context;

        public DoctorModelsController(DContext context)
        {
            _context = context;
        }

        // GET: api/DoctorModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorModel>>> Getdoctors()
        {
            return await _context.doctors.ToListAsync();
        }

        // GET: api/DoctorModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorModel>> GetDoctorModel(int id)
        {
            var doctorModel = await _context.doctors.FindAsync(id);

            if (doctorModel == null)
            {
                return NotFound();
            }

            return doctorModel;
        }

        // PUT: api/DoctorModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorModel(int id, DoctorModel doctorModel)
        {
            if (id != doctorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorModelExists(id))
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

        // POST: api/DoctorModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorModel>> PostDoctorModel(DoctorModel doctorModel)
        {
            _context.doctors.Add(doctorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorModel", new { id = doctorModel.Id }, doctorModel);
        }

        // DELETE: api/DoctorModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorModel(int id)
        {
            var doctorModel = await _context.doctors.FindAsync(id);
            if (doctorModel == null)
            {
                return NotFound();
            }

            _context.doctors.Remove(doctorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorModelExists(int id)
        {
            return _context.doctors.Any(e => e.Id == id);
        }
    }
}
