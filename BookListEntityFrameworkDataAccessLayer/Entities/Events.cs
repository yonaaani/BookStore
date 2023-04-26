namespace BookListEntityFrameworkDataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDEvent { get; set; }

        [StringLength(25)]
        public string EventName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EventDate { get; set; }

        [StringLength(255)]
        public string EventText { get; set; }

        public int? IDBook { get; set; }

        public int? IDUser { get; set; }
    }
}
