using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookListBLL.DTO
{
    public class BookListDTO
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string Overview { get; set; }
        public double Rating { get; set; }
        public int Price { get; set; }

        public bool OnCard { get; set; }
        public bool OnHeart { get; set; }

        public int IDAuthor { get; set; }
        public int IDUser { get; set; }
    }
}
