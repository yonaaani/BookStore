using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.ComponentModel;
using System.IO;

namespace MainPage.MVVM.Model
{
    [Serializable]
    [Table("BookList")]
    public class BookModel
    {
        [Key]
        public int IDBook { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(25)]
        public string BookName { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(25)]
        public string BookType { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [StringLength(255)]
        public string Overview { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        public decimal Rating { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        public int Price { get; set; }

        public IEnumerable<BookImageModel> BookImageModel { get; set; }

        [NotMapped]
        public byte[] ImageBytes { get; set; }
    }
}
