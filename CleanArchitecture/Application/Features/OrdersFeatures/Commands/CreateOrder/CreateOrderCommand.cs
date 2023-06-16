using Application.Features.OrdersFeatures.Commands.CreateOrder;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.OrdersFeatures.Commands.CreateOrder
{
    public record class CreateOrderCommand : IRequest<Orders>
    {
        public string OrderName { get; set; } 
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }

    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Orders>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Orders> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderItems = request.OrderItems.Select(item => new OrderItem
            {
                BookName = item.BookName,
                Author = item.Author,
                Price = item.Price,
                Quantity = item.Quantity
            }).ToList();

            var order = new Orders()
            {
                OrderDate = request.OrderDate,
                Status = request.Status,
                TotalAmount = request.TotalAmount,
                OrderItems = orderItems
            };

            await _unitOfWork.Repository<Orders>().AddAsync(order);
            await _unitOfWork.Save(cancellationToken);

            return order;
        }
    }
}