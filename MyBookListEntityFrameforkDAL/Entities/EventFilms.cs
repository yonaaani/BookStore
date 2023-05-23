using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameworkDAL.EntityConfigurations;

namespace MyBookListEntityFrameforkDAL.Entities
{
    [EntityTypeConfiguration(typeof(EventFilmsConfig))]
    [Table("EventFilms")]
    public class EventFilms
    {
        public EventFilms()
        {

        }

        public EventFilms(string filmName, string information)
        {
            this.FilmName = filmName;
            this.Information = information;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDFilm { get; set; }

        [StringLength(25, ErrorMessage = "FilmName cannot exceed 25 characters.")]
        public string FilmName { get; set; }

        [StringLength(255, ErrorMessage = "Information cannot exceed 255 characters.")]
        public string Information { get; set; }

        [ForeignKey("Events")]
        public int? IDEvent { get; set; }
        public virtual Events Events { get; set; }

        public virtual ICollection<Events> EventsList { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IDEvent == null)
            {
                yield return new ValidationResult("IDEvent is required.", new[] { "IDEvent" });
            }
        }
    }
}
