using InnowisePet.Services.Order.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Services.Order.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        return Ok(await _orderService.GetOrdersAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByIdAsync(Guid id)
    {
        return Ok(await _orderService.GetOrderByIdAsync(id));
    }
}