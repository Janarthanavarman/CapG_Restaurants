using CapG.Models.Dto;

namespace CapG.Services;
public interface IMenuService
{
    public Task<IEnumerable<DishDto>> GetAllAsync();
    public Task<IEnumerable<DishDto>> GetItemsByCategoryAsync(string category);
    public Task<IEnumerable<DishDto>> GetItemsByQueryAsync(IDictionary<string, string> filters);
}