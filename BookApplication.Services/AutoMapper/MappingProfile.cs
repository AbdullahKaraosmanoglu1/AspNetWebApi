using AutoMapper;

namespace BookApplication.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Admin

            //CreateMap<BaseAdminUserModel, AdminUser>().ReverseMap();



            //CreateMap<AdminUser, AdminUserModel>()
            //      .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.AdminRole.RoleName))
            //      .ReverseMap();
           

            #endregion

        }
    }
}
