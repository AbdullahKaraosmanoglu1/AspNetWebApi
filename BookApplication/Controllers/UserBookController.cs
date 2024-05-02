using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Services.Service.UserBookServices;
using BookApplication.WebApi.Models;
using BookApplication.WebApi.Models.UserBookModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookController : ControllerBase
    {
        private readonly IUserBookService _userBookService;
        private readonly IMapper _mapper;

        public UserBookController(IUserBookService userBookService, IMapper mapper)
        {
            _userBookService = userBookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllAsync()
        {
            var userBooks = await _userBookService.GetAllAsync();

            var userBookModels = _mapper.Map<IEnumerable<UserBookModel>>(userBooks);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "Sahipli Kitaplar Getirildi.";
            response.Data = userBookModels;

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseModel> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var userBook = await _userBookService.GetByIdAsync(id);

            var userBookModel = _mapper.Map<UserBookModel>(userBook);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "İstenilen Sahipli Kitap Getirildi.";
            response.Data = userBookModel;

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateUserBookAsync([FromBody] CreateUserBookModel createUserBookModel)
        {
            var userBookModel = _mapper.Map<UserBook>(createUserBookModel);

            var createUserBook = await _userBookService.CreateAsync(userBookModel);

            await _userBookService.SaveAsync();

            var userBookModelMap = _mapper.Map<UserBookModel>(createUserBook);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "Sahipli Kitap Başarılı Bir Şekilde Oluşturuldu.";
            response.Data = userBookModelMap;

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateUserBookAsync([FromBody] UpdateUserBookModel updateUserBookModel)
        {
            var userBookMap = _mapper.Map<UserBook>(updateUserBookModel);

            await _userBookService.UpdateAsync(userBookMap);

            await _userBookService.SaveAsync();

            var response = new ResponseModel();
            response.Code = "204";
            response.Message = "Sahipli Kitap Başarılı Bir Şekilde Güncellendi.";

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseModel> DeleteUserBookAsync([FromRoute(Name = "id")] int id)
        {
            await _userBookService.DeleteAsync(id);

            await _userBookService.SaveAsync();

            var response = new ResponseModel();
            response.Code = "204";
            response.Message = "Sahipli Kitap Başarılı Bir Şekilde Silindi";


            return response;
        }
    }
}
