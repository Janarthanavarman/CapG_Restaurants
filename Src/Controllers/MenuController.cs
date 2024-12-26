
using CapG.IRepositories;
using CapG.Models;
using CapG.Services;
using Microsoft.AspNetCore.Mvc;
namespace CapG.Controllers;

[Route("api/[controller]/items")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }
    [HttpGet]
    public async Task<IActionResult> get()
    {
        var items = await _menuService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("category/{category}")]
    public async Task<IActionResult> category(string category)
    {
        var items = await _menuService.GetItemsByCategoryAsync(category);
        return Ok(items);
    }
    [HttpGet("{dish_code}")]
    public async Task<IActionResult> dish_code(string dish_code)
    {
        var param = new Dictionary<string, string>
            {
                { "dish_code", dish_code }
            };
        var items = await _menuService.GetItemsByQueryAsync(param);
        return Ok(items);
    }

    [HttpGet("query")]
    public async Task<IActionResult> query_rating([FromQuery]double rating=0, [FromQuery]string spicy_level="", [FromQuery]bool available = true)
    {
        var param = new Dictionary<string, string>();
        if (rating > 0)
            param.Add("rating", rating.ToString());
        else if (!string.IsNullOrEmpty(spicy_level))
            param.Add("spicy_level", spicy_level);
        else
            param.Add("available", available.ToString());

        var items = await _menuService.GetItemsByQueryAsync(param);
        return Ok(items);
    }
}