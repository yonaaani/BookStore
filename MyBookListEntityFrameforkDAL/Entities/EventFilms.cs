using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MyBookListEntityFrameforkDAL.Entities
{
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

        [StringLength(25)]
        public string FilmName { get; set; }

        [StringLength(255)]
        public string Information { get; set; }

        public int? IDEvent { get; set; }
    }
}
