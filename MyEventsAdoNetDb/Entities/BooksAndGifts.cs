using Dapper_Example.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDb.Entities
{
    public class BooksAndGifts
    {
        public int ?IDGift { get; set; }
        public int ?IDBook { get; set; }

        public Gifts Gifts { get; set; }
        public BookList BookList { get; set; }
    }
}
