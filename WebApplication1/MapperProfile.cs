using AutoMapper;
using System.Runtime;
using WebApplication1.DtoModels.DtoAppUser;
using WebApplication1.DtoModels.DtoAuthor;
using WebApplication1.DtoModels.DtoBasket;
using WebApplication1.DtoModels.DtoBook;
using WebApplication1.DtoModels.DtoCart;
using WebApplication1.DtoModels.DtoGenres;
using WebApplication1.DtoModels.DtoOrderItems;
using WebApplication1.DtoModels.DtoOrders;
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
            CreateMap<CartItems, DtoCartShortInfo>();
            
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

            CreateMap<Books, DtoBookByName>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher));

            CreateMap<Books, DtoBookShortInfo>();
        

            CreateMap<DtoBooksCreate, Books>();
            CreateMap<DtoBooksUpdate, Books>();

            // Маппинг для Genres
            CreateMap<Genres, DtoGenres>();
            CreateMap<Genres, DtoGenresResponce>();

            // Маппинг для CartItems
            CreateMap<CartItems, DtoCart>();
            CreateMap<CartItems, DtoCartResponce>();

            CreateMap<CartItems, DtoCartResponce>()
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
            .ForMember(dest => dest.BookPrice, opt => opt.MapFrom(src => src.Book.Price));

            CreateMap<CartItems, DtoCartResponce>()
            .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
            .ForMember(dest => dest.BookPrice, opt => opt.MapFrom(src => src.Book.Price));

            CreateMap<CartItems, DtoCartCreate>()
           .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Book.Id))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id));

            CreateMap<DtoCartCreate, CartItems>()
           .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.Book, opt => opt.Ignore())  
           .ForMember(dest => dest.User, opt => opt.Ignore());

            // Маппинг для AppUsers
            CreateMap<AppUsers, DtoUser>();
            CreateMap<AppUsers, DtoUserResponce>();
            CreateMap < AppUsers, DtoUserShortInfo>();

            // Маппинг для OrdersItems
            CreateMap<OrderItems, DtoOrderItem>()
                .ForMember(dest => dest.BookShortInfo, opt => opt.MapFrom(src => src.Book));
          
            // Маппинг для Orders
            CreateMap<Orders, DtoOrders>();
            CreateMap<DtoCreateOrder, Orders>();

            CreateMap<Orders, DtoOrders>()
           .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
           .ForMember(dest => dest.AppUsers, opt => opt.MapFrom(src => src.AppUsers));
           
        }
    }
}
