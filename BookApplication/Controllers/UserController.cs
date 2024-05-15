using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Data.Models;
using BookApplication.Services.Service.RoleService;
using BookApplication.Services.Service.UserServices;
using BookApplication.Services.Services.AuthService;
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
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IAuthService authService, IMapper mapper, IRoleService roleService)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();

            var userModels = _mapper.Map<IEnumerable<User>>(users);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Kullanıcılar Getirildi.",
                Data = userModels
            };

            return response;
        }

        [HttpPost("GetAllWithPagination")]
        public async Task<ResponseModel> GetAllWithPaginationAsync([FromBody] PaginationModel paginationModel)
        {
            var users = await _userService.GetAllWithPaginationAsync(paginationModel);

            var userModel = users.Users.Select(users => _mapper.Map<UserModel>(users)).ToList();

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Kullanıcılar Getirildi.",
                Data = new { Users = userModel, users.TotalCount }
            };

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseModel> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var user = await _userService.GetByIdAsync(id);

            var userModel = _mapper.Map<UserModel>(user);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "İstenilen Kullanıcı Getirildi.",
                Data = userModel
            };

            return response;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateUserAsync([FromBody] CreateUserModel createUserModel)
        {
            var userModel = _mapper.Map<User>(createUserModel);

            var userPasswordHash = await _authService.PasswordHashAsync(createUserModel.Password);
            userModel.Password = userPasswordHash;
            var createUser = await _userService.CreateAsync(userModel);

            var userRole = await _roleService.GetByIdAsync(createUserModel.RoleId);
            var token = await _authService.GenerateJwtTokenAsync(userModel.Email, userRole.RoleName);
            userModel.AccessToken = token;
            userModel.AccessTokenCreatedDate = DateTime.Now;

            await _userService.SaveAsync();

            var userModelMap = _mapper.Map<UserModel>(createUser);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Kullanıcı Başarılı Bir Şekilde Oluşturuldu.",
                Data = userModelMap
            };

            return response;
        }

        [HttpPut]
        public async Task<ResponseModel> UpdateUserAsync([FromBody] UpdateUserModel updateUserModel)
        {
            var userMap = _mapper.Map<User>(updateUserModel);

            await _userService.UpdateAsync(userMap);

            await _userService.SaveAsync();

            var response = new ResponseModel()
            {
                Code = "204",
                Message = "Kullanıcı Başarılı Bir Şekilde Güncellendi."
            };

            return response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseModel> DeleteUserAsync([FromRoute(Name = "id")] int id)
        {
            await _userService.DeleteAsync(id);

            await _userService.SaveAsync();

            var response = new ResponseModel()
            {
                Code = "204",
                Message = "Kullanıcı Başarılı Bir Şekilde Silindi"
            };

            return response;
        }
    }
}
