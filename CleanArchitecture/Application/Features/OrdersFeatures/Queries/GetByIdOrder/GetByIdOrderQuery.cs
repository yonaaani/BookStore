using Application.Features.OrdersFeatures.Queries.GetAllOrders;
using Application.Features.OrdersFeatures.Queries.GetByIdOrder;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.OrdersFeatures.Queries.GetByIdOrder
{
    public class GetByIdOrderQuery : IRequest<GetByIdOrderDto>
    {
        public int Id { get; set; }
    }

    internal class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, GetByIdOrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetByIdOrderDto> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Orders>()
                 .Entities
                 .Include(o => o.OrderItems)
                 .FirstOrDefaultAsync(o => o.Id == request.Id);

            var dto = _mapper.Map<GetByIdOrderDto>(order);
            return dto;
        }
    }
}