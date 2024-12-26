using System.Linq.Expressions;
using AutoMapper;
using CapG;
using CapG.AppDbContext;
using CapG.IRepositories;
using CapG.Models;
using CapG.Models.Dto;
using CapG.Services;

public class MenuService : IMenuService
{
    private readonly IGenericRepository<Dishs> _dishRepository;
    private readonly IMapper _mapper;

    public MenuService(IGenericRepository<Dishs> dishRepository, IMapper mapper)
    {
        _dishRepository = dishRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DishDto>> GetAllAsync()
    {
        var dishes = await _dishRepository.GetAllAsync();

        // Map dishes to DTOs
        var dishDtos = _mapper.Map<List<DishDto>>(dishes);
        return dishDtos;
    }

    public async Task<IEnumerable<DishDto>> GetItemsByCategoryAsync(string category)
    {

        FilterCondition<Dishs> filterCondition = dish =>
        {
            bool isValid = true;
            isValid = isValid && dish.DishCategory.DishCategoryName.Contains(Convert.ToString(category));
            return isValid;
        };
        var dishes = await _dishRepository.GetItemsByDelegatsFilterAsync(filterCondition);

        // Map dishes to DTOs
        var dishDtos = _mapper.Map<List<DishDto>>(dishes);
        return dishDtos;
    }
    public async Task<IEnumerable<DishDto>> GetItemsByQueryAsync(IDictionary<string, string> filters)
    {
        Expression<Func<Dishs, bool>> filterCondition = item => true;

        if (filters != null)
            foreach (var filter in filters)
            {
                switch (filter.Key)
                {
                    case "dish_code":
                        filterCondition = dish => dish.DishCode.Contains(filter.Value);
                        break;
                    case "rating":
                        filterCondition = dish => dish.Rating >= Convert.ToDouble(filter.Value);
                        break;
                    case "spicy_level":
                        filterCondition = dish => dish.SpicyLevel.SpicyLevelName.Contains(filter.Value);
                        break;
                    case "available":
                        filterCondition = dish => dish.IsAvail == Convert.ToBoolean(filter.Value);
                        break;
                    case "category":
                        filterCondition = dish => dish.DishCategory.DishCategoryName.Contains(filter.Value);
                        break;
                }
            }

        var dishes = await _dishRepository.GetItemsByExpFilterAsync(filterCondition);
        // Map dishes to DTOs
        var dishDtos = _mapper.Map<List<DishDto>>(dishes);
        return dishDtos;
    }
}
