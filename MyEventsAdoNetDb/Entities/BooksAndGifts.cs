using Dapper_Example.DAL;
using System;
using System.Collections.Generic;

namespace MyEventsAdoNetDb.Entities
{
    public class BooksAndGifts
    {
        public BooksAndGifts()
        {

        }

        public BooksAndGifts(int? idGift, int? idBook)
        {
            this.IDGift = idGift;
            this.IDBook = idBook;
        }

        public int? IDGift { get; set; }
        public int? IDBook { get; set; }

        public Gifts Gifts { get; set; }
        public BookList BookList { get; set; }
    }
}
