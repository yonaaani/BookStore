namespace BookListEntityFrameworkDataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventDiscounts")]
    public class EventDiscounts
    {
        public EventDiscounts()
        {

        }

        public EventDiscounts(double discountPercentage)
        {
            this.DiscountPercentage = discountPercentage;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDiscount { get; set; }

        public double? DiscountPercentage { get; set; }

        public int? IDEvent { get; set; }
    }
}
