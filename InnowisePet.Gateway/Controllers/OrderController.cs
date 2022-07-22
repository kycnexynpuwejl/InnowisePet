using InnowisePet.HttpClients;
using InnowisePet.Models.DTO.Order;
using Microsoft.AspNetCore.Mvc;

namespace InnowisePet.Gateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderClient _orderClient;
    
    public OrderController(OrderClient orderClient)
    {
        _orderClient = orderClient;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersAsync()
    {
        return Ok(await _orderClient.GetOrdersAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _orderClient.GetOrderByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(OrderCreateDto orderCreateDto)
    {
        //orderCreateDto.UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        await _orderClient.CreateOrderAsync(orderCreateDto);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderAsync(OrderUpdateDto orderUpdateDto)
    {
        await _orderClient.UpdateOrderAsync(orderUpdateDto);

        return Ok();
    }
    
    /*[HttpPut("list")]
    public async Task<IActionResult> UpdateOrdersAsync(IEnumerable<OrderUpdateDto> orderUpdateDtoList)
    {
        OrderUpdateDtoList list = new() { List = orderUpdateDtoList };
        await _publishEndpoint.Publish(list);

        return Ok();
    }*/

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderAsync([FromRoute] Guid id)
    {
        OrderDeleteDto orderDeleteDto = new() { Id = id };
        await _orderClient.DeleteOrderAsync(orderDeleteDto);

        return Ok();
    }
}