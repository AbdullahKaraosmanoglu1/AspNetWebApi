using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Services.Service.UserServices;
using BookApplication.WebApi.Models;
using BookApplication.WebApi.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();

            var userModels = _mapper.Map<IEnumerable<User>>(users);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "Kullanıcılar Getirildi.";
            response.Data = userModels;

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseModel> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var user = await _userService.GetByIdAsync(id);

            var userModel = _mapper.Map<UserModel>(user);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "İstenilen Kullanıcı Getirildi.";
            response.Data = userModel;

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateUserAsync([FromBody] CreateUserModel createUserModel)
        {
            var userModel = _mapper.Map<User>(createUserModel);

            var createUser = await _userService.CreateAsync(userModel);

            await _userService.SaveAsync();

            var userModelMap = _mapper.Map<UserModel>(createUser);

            var response = new ResponseModel();
            response.Code = "200";
            response.Message = "Kullanıcı Başarılı Bir Şekilde Oluşturuldu.";
            response.Data = userModelMap;

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateUserAsync([FromBody] UpdateUserModel updateUserModel)
        {
            var userMap = _mapper.Map<User>(updateUserModel);

            await _userService.UpdateAsync(userMap);

            await _userService.SaveAsync();

            var response = new ResponseModel();
            response.Code = "204";
            response.Message = "Kullanıcı Başarılı Bir Şekilde Güncellendi.";

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseModel> DeleteUserAsync([FromRoute(Name = "id")] int id)
        {
            await _userService.DeleteAsync(id);

            await _userService.SaveAsync();

            var response = new ResponseModel();
            response.Code = "204";
            response.Message = "Kullanıcı Başarılı Bir Şekilde Silindi";


            return response;
        }
    }
}
