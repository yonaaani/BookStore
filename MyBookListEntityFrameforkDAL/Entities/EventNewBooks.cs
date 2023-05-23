using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameforkDAL.EntityConfigurations;
using MyBookListEntityFrameworkDAL.EntityConfigurations;

namespace MyBookListEntityFrameforkDAL.Entities
{
    [EntityTypeConfiguration(typeof(EventNewBooksConfig))]
    [Table("EventNewBooks")]
    public class EventNewBooks
    {
        public EventNewBooks()
        {

        }

        public EventNewBooks(string bookName, string author, string information)
        {
            this.BookName = bookName;
            this.Author = author;
            this.Information = information;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDNewBook { get; set; }

        [StringLength(25, ErrorMessage = "BookName cannot exceed 25 characters.")]
        public string BookName { get; set; }

        [StringLength(25, ErrorMessage = "Author cannot exceed 25 characters.")]
        public string Author { get; set; }

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
