using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MyBookListEntityFrameforkDAL.Entities
{
    [Table("EventDiscounts")]
    public class EventDiscounts
    {
        public EventDiscounts()
        {

        }

        public EventDiscounts(double discountPercentage)
        {
            DiscountPercentage = discountPercentage;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDiscount { get; set; }

        public double? DiscountPercentage { get; set; }

        public int? IDEvent { get; set; }
    }
}
