using AutoMapper;
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
}
