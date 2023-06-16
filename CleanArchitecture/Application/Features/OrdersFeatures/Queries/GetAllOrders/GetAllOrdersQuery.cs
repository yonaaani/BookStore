﻿using Application.Features.OrdersFeatures.Queries.GetAllOrders;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.OrdersFeatures.Queries.GetAllOrders
{
    public record class GetAllOrdersQuery : IRequest<List<GetAllOrdersDto>>
    {
    }
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<GetAllOrdersDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllOrdersDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Repository<Orders>()
                .Entities
                .Include(o => o.OrderItems)
                .ToListAsync();

            var dtos = _mapper.Map<List<GetAllOrdersDto>>(orders);
            return dtos;
        }
    }
}