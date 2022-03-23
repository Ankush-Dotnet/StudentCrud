using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4_Razor.Model;

namespace WebApplication4_Razor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Book book { get; set; }
        public async Task OnGet(int id)
        {
          book =  await _context.Books.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {

                var BookInDb = await _context.Books.FindAsync(book.Id);
                if (BookInDb == null)
                    return NotFound();
                BookInDb.Name = book.Name;
                BookInDb.Author = book.Author;
                BookInDb.ISBN = book.ISBN;
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
