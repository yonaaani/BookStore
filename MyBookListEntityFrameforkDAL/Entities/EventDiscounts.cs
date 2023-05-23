using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Range(0, 100, ErrorMessage = "DiscountPercentage must be between 0 and 100.")]
        public double? DiscountPercentage { get; set; }

        [ForeignKey("Events")]
        public int? IDEvent { get; set; }
        public virtual Events Events { get; set; }

        public virtual ICollection<Events> EventsList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DiscountPercentage == null)
            {
                yield return new ValidationResult("DiscountPercentage is required.", new[] { "DiscountPercentage" });
            }
        }
    }
}
