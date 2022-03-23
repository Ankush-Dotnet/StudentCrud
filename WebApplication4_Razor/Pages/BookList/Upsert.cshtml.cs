using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4_Razor.Model; 
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication4_Razor.Pages.BookList
{ 
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }[BindProperty]
        public Student Student { get; set; }
        public async Task <IActionResult> OnGet(int? id)
        {
            Student = new Student();
            if (id == null)
                return Page();
            Student = await _context.Students.FindAsync(id);
            return Page();
        }
        public async Task <IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return NotFound();
            if (Student.Id== 0)
                await _context.Students.AddAsync(Student);
            else
                _context.Students.Update(Student);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
        }
    }
}
