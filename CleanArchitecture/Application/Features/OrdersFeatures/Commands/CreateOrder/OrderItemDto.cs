namespace Application.Features.OrdersFeatures.Commands.CreateOrder
{
    public class OrderItemDto
    {
        public string BookName { get; set; } = default!;
        public string Author { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}