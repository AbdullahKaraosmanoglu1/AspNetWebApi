using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Services.Service.UserServices;
using BookApplication.Services.Services.AuthService;
using BookApplication.WebApi.Models;
using BookApplication.WebApi.Models.LoginModels;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IAuthService authService, IUserService userService, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("UserLogin")]
        public async Task<ResponseModel> UserLoginAsync([FromBody] LoginModel loginModel)
        {
            var userMap = _mapper.Map<User>(loginModel);

            var user = await _authService.UserLoginAsync(userMap);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Üye Girişi Başarılı.",
                Data = user.AccessToken
            };

            return response;
        }
    }
}
