using BookApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.BooksList;

            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBooks([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .BooksList
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (book is null)
                return NotFound();

            return Ok(book);
        }
    }
}
