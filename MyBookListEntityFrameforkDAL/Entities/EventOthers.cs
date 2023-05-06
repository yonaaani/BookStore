using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
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

        public EventOthers(string otherName, string discription)
        {
           this.OtherName = otherName;
           this.Discription = discription;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOther { get; set; }

        [StringLength(25)]
        public string OtherName { get; set; }

        [StringLength(255)]
        public string Discription { get; set; }

        public int? IDEvent { get; set; }

        public virtual ICollection<Events> Events{ get; set; }
    }
}
