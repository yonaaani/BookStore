using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Domain.Queries
{
    public record GetOrderListQuery() : IRequest<List<Order>>;
  
    //public class GetOrderListQuetyClass : IRequest<List<Order>>
    //{

    //}
}
