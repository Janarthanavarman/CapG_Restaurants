using AutoMapper;
using CapG.Models.Dto;
namespace CapG.Models.AutoMappers;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping between Dish entity and DishDto
        CreateMap<Dishs, DishDto>()
            .ForMember(dest => dest.DishCategoryName, opt => opt.MapFrom(src => src.DishCategory.DishCategoryName))
            .ForMember(dest => dest.SpicyLevelName, opt => opt.MapFrom(src => src.SpicyLevel.SpicyLevelName));
    }
}
