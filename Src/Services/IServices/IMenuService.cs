using CapG.Models.Dto;

namespace CapG.Services;
public interface IMenuService
{
    public Task<IEnumerable<DishDto>> GetAllAsync();
}