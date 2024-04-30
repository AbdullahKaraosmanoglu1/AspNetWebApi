using AutoMapper;
using BookApplication.Data.Entity;
using BookApplication.WebApi.Models.UserModels;

namespace BookApplication.WebApi.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<BookModel, Book>().ReverseMap();
        }
    }
}
