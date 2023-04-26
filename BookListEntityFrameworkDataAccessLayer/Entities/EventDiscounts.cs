namespace BookListEntityFrameworkDataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventDiscounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDiscount { get; set; }

        public double? DiscountPercentage { get; set; }

        public int? IDEvent { get; set; }
    }
}
