using Domain.Common;

namespace Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public string BookName { get; set; } = default!;
        public string Author { get; set; } = default!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Orders Orders { get; set; } = default!; //one to many
    }
}