using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.MVVM.Model
{
    [Serializable]
    [Table("BooksImages")]
    public class BookImageModel
    {
        [Key]
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string FileExtension { get; set; }

        public decimal Size { get; set; }

        [ForeignKey("BookModel")]
        public int IDBook { get; set; }
        public virtual BookModel BookModel { get; set; }
    }
}
