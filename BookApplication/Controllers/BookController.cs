using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Services.Service.BookServices;
using BookApplication.Services.SlugHelper;
using BookApplication.WebApi.Models;
using BookApplication.WebApi.Models.BookCategoryModels;
using BookApplication.WebApi.Models.BookModels;
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

        [HttpGet]
        public async Task<ResponseModel> GetAllAsync()
        {
            var books = await _bookService.GetAllAsync();

            var bookModel = _mapper.Map<IEnumerable<BookModel>>(books);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "Bütün Kitaplar Getirildi.";
            response.Data = bookModel;

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseModel> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _bookService.GetByIdAsync(id);

            var bookModel = _mapper.Map<BookModel>(book);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "İstenilen Kitap Getirildi.";
            response.Data = bookModel;

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateBookAsync([FromBody] CreateBookModel createBookModel)
        {
            var bookModel = _mapper.Map<Book>(createBookModel);           

            var createBook = await _bookService.CreateAsync(bookModel);

            await _bookService.SaveAsync();

            var bookModelMap = _mapper.Map<BookModel>(createBook);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "Kitap Başarılı Bir Şekilde Oluşturuldu.";
            response.Data = bookModelMap;

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateBookAsync([FromBody] UpdateBookModel updateBookModel)
        {
            var bookMap = _mapper.Map<Book>(updateBookModel);

            await _bookService.UpdateAsync(bookMap);

            await _bookService.SaveAsync();

            var response = new ResponseModel();
            response.Code = "204";
            response.Message = "Kitap Başarılı Bir Şekilde Güncellendi.";

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseModel> DeleteBookAsync([FromRoute(Name = "id")] int id)
        {
            await _bookService.DeleteAsync(id);

            await _bookService.SaveAsync();

            var response = new ResponseModel();
            response.Code = "204";
            response.Message = "Kitap Başarılı Bir Şekilde Silindi";


            return response;
        }
    }
}
