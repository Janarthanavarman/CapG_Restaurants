
using CapG.IRepositories;
using CapG.Models;
using CapG.Services;
using Microsoft.AspNetCore.Mvc;
namespace CapG.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var items = await _menuService.GetAllAsync();
        return Ok(items);
    }
}