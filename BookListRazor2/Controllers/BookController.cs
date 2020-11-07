using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor2.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor2.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList() });
        }
    }
}
