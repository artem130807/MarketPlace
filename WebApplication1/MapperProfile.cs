using AutoMapper;
using System.Runtime;
using WebApplication1.DtoModels.DtoAuthor;
using WebApplication1.DtoModels.DtoBook;
using WebApplication1.DtoModels.DtoGenres;
using WebApplication1.DtoModels.DtoPublishers;
using WebApplication1.Models;

namespace WebApplication1
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {

            // Маппинг для упрощенных DTO
            CreateMap<Authors, DtoAuthorShortInfo>();
            CreateMap<Books, DtoBookShortInfo>();
            CreateMap<Publishers, DtoPublisherShortInfo>();
            CreateMap<Genres, DtoGenresShortInfo>();

            // Маппинг для Author
            CreateMap<Authors, DtoAuthors>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<Authors, DtoAuthorsResponce>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<DtoCreateAuthor, Authors>();
            CreateMap<DtoUpdateAuthors, Authors>();

            // Маппинг для Book
            CreateMap<Books, DtoBooks>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher));


            CreateMap<Books, DtoBookResponce>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher));



            CreateMap<DtoBooksCreate, Books>();
            CreateMap<DtoBooksUpdate, Books>();

            // Маппинг для Genres
            CreateMap<Genres, DtoGenres>();
            CreateMap<Genres, DtoGenresResponce>();
        }
    }
}
