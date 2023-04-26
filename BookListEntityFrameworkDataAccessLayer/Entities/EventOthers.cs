namespace BookListEntityFrameworkDataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventOthers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOther { get; set; }

        [StringLength(25)]
        public string OtherName { get; set; }

        [StringLength(255)]
        public string Discription { get; set; }

        public int? IDEvent { get; set; }
    }
}