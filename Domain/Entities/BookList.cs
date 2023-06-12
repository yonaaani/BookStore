﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookList : BaseEntity
    {

        public string BookName { get; set; } = default!;
        public string BookType { get; set; } = default!;
        public string Overview { get; set; } = default!;
        public double Rating { get; set; }
        public int Price { get; set; }

        public bool OnCard { get; set; }
        public bool OnHeart { get; set; }

        public ICollection<BooksAndAuthors> BooksAndAuthors { get; private set; } // many-to-many


        public BookList()
        {
            BooksAndAuthors = new HashSet<BooksAndAuthors>();
        }
    }
}