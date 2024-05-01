using AutoMapper;
using BookApplication.Services.Service.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BookController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }
    }
}
