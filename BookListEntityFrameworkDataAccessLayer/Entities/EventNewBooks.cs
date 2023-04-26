namespace BookListEntityFrameworkDataAccessLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventNewBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDNewBook { get; set; }

        [StringLength(25)]
        public string BookName { get; set; }

        [StringLength(25)]
        public string Author { get; set; }

        [StringLength(255)]
        public string Information { get; set; }

        public int? IDEvent { get; set; }
    }
}
