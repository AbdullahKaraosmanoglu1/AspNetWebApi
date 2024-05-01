using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.WebApi.Models.BookCategoryModels;
using BookApplication.WebApi.Models.BookModels;

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
        }
    }
}
