using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor2.Pages.BookList
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }


        public async Task<IActionResult> Onpost()
        {
            if (ModelState.IsValid)
            {
                var BookFromdb = await _db.Book.FindAsync(Book.Id);
                BookFromdb.Name = Book.Name;
                BookFromdb.Author = Book.Author;
                BookFromdb.ISBN = Book.ISBN;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            return RedirectToPage();
        } 
    }
}
