using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyEventsAdoNetDb.Entities;
using MyBookListEntityFrameworkDAL.EntityConfiguration;
using Dapper_Example.DAL;
using Microsoft.EntityFrameworkCore;

namespace MyBookListEntityFrameforkDAL.Entities
{
    [EntityTypeConfiguration(typeof(EventsConfig))]
    [Table("Events")]
    public class Events : IValidatableObject
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

        [Required(ErrorMessage = "EventName is required.")]
        [StringLength(25, ErrorMessage = "EventName cannot exceed 25 characters.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "EventDate is required.")]
        [FutureDate(ErrorMessage = "EventDate must be a future date.")]
        public DateTime EventDate { get; set; }

        [StringLength(255, ErrorMessage = "EventText cannot exceed 255 characters.")]
        public string EventText { get; set; }

        [Required(ErrorMessage = "IDBook is required.")]
        [ForeignKey("BookList")]
        public int? IDBook { get; set; }
        public BookList BookList { get; set; }

        [Required(ErrorMessage = "IDUser is required.")]
        [ForeignKey("Users")]
        public int? IDUser { get; set; }
        public Users Users { get; set; }

        public virtual ICollection<EventOthers> EventOthers { get; set; }
        public virtual ICollection<EventNewBooks> EventNewBooks { get; set; }
        public virtual ICollection<EventFilms> EventFilms { get; set; }
        public virtual ICollection<EventDiscounts> EventDiscounts { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IDBook == null && IDUser == null)
            {
                yield return new ValidationResult("Either IDBook or IDUser must be specified.", new[] { "IDBook", "IDUser" });
            }
        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = (DateTime)value;
            return dateTime > DateTime.Now;
        }
    }
}
