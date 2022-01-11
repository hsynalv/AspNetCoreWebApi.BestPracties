using AutoMapper;
using UdemyNlayerProject.API.DTOs;
using UdemyNLayerProject.Core.Models;

namespace UdemyNlayerProject.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductWithCategoryDto, Product>().ReverseMap();
        }
    }
}
