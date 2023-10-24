using AutoMapper;

namespace BookInfo.API.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Book, Models.BookWithoutPointsOfInterestDto>();
            CreateMap<Entities.Book, Models.BookDto>();
        }
    }
}
