using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Dapper_Example.DAL;
using MyEventsAdoNetDb.Entities;
using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameworkDAL.EntityConfiguration;

namespace MyBookListEntityFrameforkDAL.Entities
{
    [EntityTypeConfiguration(typeof(EventsConfig))]
    [Table("Events")]
    public class Events
    {
        public Events()
        {
        
        }

        public Events(string eventName, DateTime eventDate, string eventText)
        {
            this.EventName = eventName;
            this.EventDate = eventDate;
            this.EventText = eventText;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDEvent { get; set; }

        [StringLength(25)]
        public string EventName { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [StringLength(255)]
        public string EventText { get; set; }

        [Required]
        [ForeignKey("BookList")]
        public int? IDBook { get; set; }
        public BookList BookList { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int? IDUser { get; set; }
        public Users Users { get; set; }

        public virtual ICollection<EventOthers> EventOthers { get; set; }
        public virtual ICollection<EventNewBooks> EventNewBooks { get; set; }
        public virtual ICollection<EventFilms> EventFilms { get; set; }
        public virtual ICollection<EventDiscounts> EventDiscounts { get; set; }
    }
}
