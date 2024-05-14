using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Services.Service.BookServices;
using BookApplication.WebApi.Models;
using BookApplication.WebApi.Models.BookModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ResponseModel> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();

            var bookModel = _mapper.Map<IEnumerable<BookModel>>(books);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Bütün Kitaplar Getirildi.",
                Data = bookModel
            };

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseModel> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            var bookModel = _mapper.Map<BookModel>(book);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "İstenilen Kitap Getirildi.",
                Data = bookModel
            };     

            return response;
        }

        [HttpGet("Category/{categoryId:int}")]
        public async Task<ResponseModel> GetBooksByCategoryIdAsync([FromRoute(Name = "categoryId")] int categoryId)
        {
            var book = await _bookService.GetBooksByCategoryIdAsync(categoryId);

            var bookModel = _mapper.Map<IEnumerable<BookModel>>(book);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Kategoriye Ait Kitaplar Getirildi.",
                Data = bookModel
            };

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateBookAsync([FromBody] CreateBookModel createBookModel)
        {
            var bookModel = _mapper.Map<Book>(createBookModel);

            var createBook = await _bookService.CreateAsync(bookModel);

            await _bookService.SaveAsync();

            var bookModelMap = _mapper.Map<BookModel>(createBook);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Kitap Başarılı Bir Şekilde Oluşturuldu.",
                Data = bookModelMap
            };

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateBookAsync([FromBody] UpdateBookModel updateBookModel)
        {
            var bookMap = _mapper.Map<Book>(updateBookModel);

            await _bookService.UpdateAsync(bookMap);

            await _bookService.SaveAsync();

            var response = new ResponseModel()
            {
                Code = "204",
                Message = "Kitap Başarılı Bir Şekilde Güncellendi."
            };

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseModel> DeleteBookAsync([FromRoute(Name = "id")] int id)
        {
            await _bookService.DeleteAsync(id);

            await _bookService.SaveAsync();

            var response = new ResponseModel()
            {
                Code = "204",
                Message = "Kitap Başarılı Bir Şekilde Silindi"
            };

            return response;
        }
    }
}
