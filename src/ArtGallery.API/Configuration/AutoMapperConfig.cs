using ArtGallery.API.Dtos.Category;
using ArtGallery.API.Dtos.Comment;
using ArtGallery.API.Dtos.Item;
using ArtGallery.API.Dtos.Rating;
using ArtGallery.Domain.Models;
using AutoMapper;

namespace ArtGallery.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Category, CategoryResultDto>().ReverseMap();

            CreateMap<Item, ItemAddDto>().ReverseMap();
            CreateMap<Item, ItemEditDto>().ReverseMap();
            CreateMap<Item, ItemResultDto>().ReverseMap();

            CreateMap<Comment, CommentAddDto>().ReverseMap();
            CreateMap<Comment, CommentEditDto>().ReverseMap();
            CreateMap<Comment, CommentResultDto>().ReverseMap();

            CreateMap<Rating, RatingAddDto>().ReverseMap();
            CreateMap<Rating, RatingEditDto>().ReverseMap();
            CreateMap<Rating, RatingResultDto>().ReverseMap();
        }
    }
}
