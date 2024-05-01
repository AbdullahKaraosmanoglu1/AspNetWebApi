using AutoMapper;
using BookApplication.Data.Entity;
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
        }
    }
}
