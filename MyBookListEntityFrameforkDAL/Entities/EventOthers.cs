using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameworkDAL.EntityConfigurations;

namespace MyBookListEntityFrameforkDAL.Entities
{
    [EntityTypeConfiguration(typeof(EventOthersConfig))]
    [Table("EventOthers")]
    public class EventOthers
    {
        public EventOthers()
        {

        }

        public EventOthers(string otherName, string description)
        {
            this.OtherName = otherName;
            this.Description = description;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOther { get; set; }

        [StringLength(25, ErrorMessage = "OtherName cannot exceed 25 characters.")]
        public string OtherName { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Description { get; set; }

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
