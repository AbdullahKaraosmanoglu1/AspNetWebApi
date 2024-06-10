using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Services.Service.BookCategoryServices;
using BookApplication.WebApi.Models;
using BookApplication.WebApi.Models.BookCategoryModels;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;
        private readonly IMapper _mapper;

        public BookCategoryController(IBookCategoryService bookCategoryService, IMapper mapper)
        {
            _bookCategoryService = bookCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllAsync()
        {
            var bookCategories = await _bookCategoryService.GetAllAsync();

            var bookCategoryModel = _mapper.Map<IEnumerable<BookCategoryModel>>(bookCategories);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Bütün Kitaplar Kategorileri Getirildi.",
                Data = bookCategoryModel
            };

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseModel> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var bookCategory = await _bookCategoryService.GetByIdAsync(id);

            var bookCategoryModel = _mapper.Map<BookCategoryModel>(bookCategory);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "İstenilen Kitap Kategorisi Getirildi.",
                Data = bookCategoryModel
            };            

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateBookCategoryAsync([FromBody] CreateBookCategoryModel createBookCategoryModel)
        {
            var bookCategoryModel = _mapper.Map<BookCategory>(createBookCategoryModel);

            var createBookCategory = await _bookCategoryService.CreateAsync(bookCategoryModel);

            await _bookCategoryService.SaveAsync();

            var bookCategoryModelMap = _mapper.Map<BookCategoryModel>(createBookCategory);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Kitap Kategorisi Başarılı Bir Şekilde Oluşturuldu.",
                Data = bookCategoryModelMap
            };            

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateBookCategoryAsync([FromBody] UpdateBookCategoryModel updateBookCategoryModel)
        {
            var bookCategoryMap = _mapper.Map<BookCategory>(updateBookCategoryModel);

            await _bookCategoryService.UpdateAsync(bookCategoryMap);

            await _bookCategoryService.SaveAsync();

            var response = new ResponseModel()
            {
                Code = "204",
                Message = "Kitap Kategorisi Başarılı Bir Şekilde Güncellendi."
            };            

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseModel> DeleteBookCategoryAsync([FromRoute(Name = "id")] int id)
        {
            await _bookCategoryService.DeleteAsync(id);

            await _bookCategoryService.SaveAsync();

            var response = new ResponseModel()
            {
                Code = "204",
                Message = "Kitap Kategorisi Başarılı Bir Şekilde Silindi"
            };

            return response;
        }
    }
}
