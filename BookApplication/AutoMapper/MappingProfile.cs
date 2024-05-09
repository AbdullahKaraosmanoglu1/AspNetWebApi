using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.WebApi.Models.BookCategoryModels;
using BookApplication.WebApi.Models.BookModels;
using BookApplication.WebApi.Models.LoginModels;
using BookApplication.WebApi.Models.RoleModels;
using BookApplication.WebApi.Models.UserBookModels;
using BookApplication.WebApi.Models.UserModels;

namespace BookApplication.WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region BOOK
            CreateMap<BookModel, Book>().ReverseMap();
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<UpdateBookModel, Book>().ReverseMap();
            #endregion

            #region BOOKCATEGORY
            CreateMap<BookCategoryModel, BookCategory>().ReverseMap();
            CreateMap<CreateBookCategoryModel, BookCategory>().ReverseMap();
            CreateMap<UpdateBookCategoryModel, BookCategory>().ReverseMap();
            #endregion

            #region USERBOOK
            CreateMap<UserBookModel, UserBook>().ReverseMap();
            CreateMap<CreateUserBookModel, UserBook>().ReverseMap();
            CreateMap<UpdateUserBookModel, UserBook>().ReverseMap();
            #endregion

            #region USER
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<CreateUserModel, User>().ReverseMap();
            CreateMap<UpdateUserModel, User>().ReverseMap();
            CreateMap<LoginModel, User>().ReverseMap();
            #endregion

            #region ROLE
            CreateMap<RoleModel, Role>().ReverseMap();
            CreateMap<RoleModel, CreateUserModel>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            #endregion
        }
    }
}
