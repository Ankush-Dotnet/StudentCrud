using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4_Razor.Model;

namespace WebApplication4_Razor.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Student =  _context.Students.ToList();
            return Json(new { data = Student });
        }
        [HttpDelete]
        public async Task <IActionResult> Delete(int id)
        {
            
            var studentindb = await _context.Students.FindAsync(id);
            if (studentindb == null)
                return Json(new { success = false, message = "Error while Delete Data!!" });
            _context.Students.Remove(studentindb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Data Sucessfully Deleted!!" });
        }
    }
}
