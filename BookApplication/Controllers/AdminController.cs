using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.Services.Services.AdminService;
using BookApplication.WebApi.Models;
using BookApplication.WebApi.Models.AdminModels;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllAsync()
        {
            var admins = await _adminService.GetAllAsync();

            var adminMap = _mapper.Map<IEnumerable<AdminModel>>(admins);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Admin Kullanıcıları getirildi.",
                Data = adminMap
            };

            return response;
        }

        [HttpGet("{id:int}")]
        public async Task<ResponseModel> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var admin = await _adminService.GetByIdAsync(id);

            var adminMap = _mapper.Map<AdminModel>(admin);

            var response = new ResponseModel()
            {
                Code = "200",
                Message = "Admin getirildi.",
                Data = adminMap
            };

            return response;
        }

        //[HttpDelete("DeleteAdminUser/{id}")]
        //public async Task<ResponseModel> DeleteAdminUserAsync(int id)
        //{
        //    await _adminService.DeleteAsync(id);

        //    await _adminService.SaveAsync();

        //    var response = new ResponseModel();
        //    response.Code = "200";
        //    response.Message = "Admin Kullanıcı başarılı bir şekilde silindi.";

        //    return response;
        //}
    }
}
