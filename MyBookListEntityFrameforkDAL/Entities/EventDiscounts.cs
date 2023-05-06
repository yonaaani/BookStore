using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameworkDAL.EntityConfigurations;

namespace MyBookListEntityFrameforkDAL.Entities
{
    [EntityTypeConfiguration(typeof(EventDiscountsConfig))]
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

        public virtual ICollection<Events> Events { get; set; }
    }
}
