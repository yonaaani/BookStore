using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Queries;
using Domain.Models;
using Domain.DataAccess;

namespace Domain.Handlers
{
    public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<Order>>
    {
        private readonly IDataAccess _data;
        public GetOrderListHandler(IDataAccess data) 
        {
            _data = data;
        }
        public Task<List<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetOrders());
        }
    }
}
