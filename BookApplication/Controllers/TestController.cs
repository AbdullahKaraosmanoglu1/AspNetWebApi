//using AutoMapper;
//using BookApplication.Data;
//using BookApplication.Data.Entity;
//using BookApplication.Services.Service.BookServices;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;

//namespace BookApplication.Controllers
//{
//    [Route("api/Books")]
//    [ApiController]
//    public class TestController : ControllerBase
//    {
//        private readonly ILogger<TestController> _logger;
//        private readonly IMapper _mapper;
//        private readonly IBookService _bookService;

//        public TestController(ILogger<TestController> logger, IMapper mapper, IBookService bookService)
//        {
//            _logger = logger;
//            _mapper = mapper;
//            _bookService = bookService;
//        }

//        [HttpGet]
//        public IActionResult GetAllBooks()
//        {
//            var books = ApplicationContext.BooksList;

//            _logger.LogInformation("GetAllBooks action has been called");

//            return Ok(books);
//        }

//        [HttpGet("{id:int}")]
//        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
//        {
//            var book = ApplicationContext
//                .BooksList
//                .Where(x => x.Id == id)
//                .FirstOrDefault();

//            if (book is null)
//            {
//                _logger.LogWarning("GetOneBook action has been called. Book is null ");

//                return NotFound();
//            }

//            _logger.LogInformation("GetOneBook action has been called");

//            return Ok(book);
//        }

//        [HttpPost]

//        public IActionResult CreateBook([FromBody] BookModel bookModel)
//        {

//            var bookModelMap = _mapper.Map<Book>(bookModel);

//            var createBook = _bookService.CreateAsync(bookModelMap);


//            //    var adminUserModel = _mapper.Map<AdminUser>(createAdminModel);

//            //    var createAdminUser = await _adminUserService.CreateAsync(adminUserModel);

//            //if (bookModel is null)
//            //{
//            //    _logger.LogWarning("BookModel is null");
//            //    return BadRequest(); //404
//            //}

//            //ApplicationContext.BooksList.Add(bookModel);

//            //_logger.LogInformation("CreateBook action has been called");

//            return Ok(createBook);
//        }

//        [HttpPut("{id:int}")]
//        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] BookModel bookModel)
//        {
//            //Check Book?
//            var entity = ApplicationContext
//                .BooksList
//                .Find(x => x.Id.Equals(id));

//            if (entity is null)
//            {
//                _logger.LogWarning("BookModel Not Found.");
//                return NotFound();
//            }

//            //Check id?
//            if (id != bookModel.Id)
//            {
//                _logger.LogWarning("Bad Request.");
//                return BadRequest(id);
//            }

//            ApplicationContext.BooksList.Remove(entity);
//            bookModel.Id = entity.Id;
//            ApplicationContext.BooksList.Add(bookModel);
//            return NoContent();


//        }

//        [HttpDelete("{id:int}")]
//        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
//        {
//            var book = ApplicationContext
//                           .BooksList
//                           .Find(x => x.Id.Equals(id));

//            if (book is null)
//            {
//                _logger.LogWarning("Book Not Found.");
//                return NotFound();
//            }

//            if (id != book.Id)
//            {
//                _logger.LogWarning("Bad Request.");
//                return BadRequest(id);
//            }

//            ApplicationContext.BooksList.Remove(book);
//            return NoContent();
//        }

//        [HttpPatch("{id:int}")]
//        public IActionResult PartiallyUpdateBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookModel> bookPatch)
//        {
//            var entity = ApplicationContext.BooksList.Find(x => x.Id.Equals(id));

//            if (entity is null)
//            {
//                _logger.LogWarning("BookPatch Not Found.");
//                return NotFound();
//            }

//            bookPatch.ApplyTo(entity);
//            return NoContent();
//        }
//    }
//}
