using Application.Features.OrdersFeatures.Commands.CreateOrder;
using Domain.Enums;

namespace Application.Features.OrdersFeatures.Queries.GetAllOrders
{
    public class GetAllOrdersDto
    {
        public int Id { get; set; }
        public string OrderName { get; set; } = default!;
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public string StatusString { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = default!;
    }
}