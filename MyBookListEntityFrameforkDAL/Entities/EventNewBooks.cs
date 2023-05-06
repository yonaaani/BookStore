using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyBookListEntityFrameforkDAL.EntityConfigurations;

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

        [StringLength(25)]
        public string BookName { get; set; }

        [StringLength(25)]
        public string Author { get; set; }

        [StringLength(255)]
        public string Information { get; set; }

        public int? IDEvent { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
