using Application.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class OrderController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Order>> Get()
    {
        return await Mediator.Send(new GetOrderListQuery());
    }
}
