using EmployeeInfoSystem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfoSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase

    {


        private readonly EmployeeContext _context;

        public DepartmentController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDepartment>>> getTblDepartment()
        {
            return await _context.TblDepartment.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TblDepartment>> TblDepartment(TblDepartment department)
        {
            _context.TblDepartment.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTblDepartment", new { id = department.Id }, department);
        }


       [HttpPut("{id}")]
       public async Task<ActionResult<IEnumerable<TblDepartment>>> PutTblDepartment(TblDepartment department, int id)
    {
         if(id!= department.Id){
                return BadRequest();
            }
         _context.Entry(TblDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDepartmentExist(id))
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

        private bool TblDepartmentExist(int id)
        {
            return _context.TblDepartment.Any(e => e.Id == id);
        }
    }


    }
    

