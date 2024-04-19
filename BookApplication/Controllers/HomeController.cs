using BookApplication.Data;
using BookApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.BooksList;

            _logger.LogInformation("GetAllBooks action has been called");

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext
                .BooksList
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (book is null)
            {
                _logger.LogWarning("GetOneBook action has been called. Book is null ");

                return NotFound();
            }

            _logger.LogInformation("GetOneBook action has been called");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] BookModel bookModel)
        {
            if (bookModel is null)
            {
                _logger.LogWarning("CreateBook action has been called. BookModel is null");
                return BadRequest(); //404
            }

            ApplicationContext.BooksList.Add(bookModel);

            _logger.LogInformation("CreateBook action has been called");

            return Ok(bookModel);
        }
    }
}
