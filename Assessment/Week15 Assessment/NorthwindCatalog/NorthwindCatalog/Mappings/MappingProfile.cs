using AutoMapper;
using NorthwindCatalog.DTOs;
using NorthwindCatalog.Models;

namespace NorthwindCatalog.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => "/images/" + src.CategoryId + ".jpeg"));

            CreateMap<Product, ProductDto>();
        }
    }
}
