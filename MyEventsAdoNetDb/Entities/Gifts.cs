﻿using Dapper_Example.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDb.Entities
{
    public class Gifts : BaseEntity 
    {
        public string GiftName { get; set; }
        public string GiftText { get; set; }
        public int GiftPrice { get; set; }
        public int IDUser { get; set; }
        public Users Users { get; set; }
        public virtual ICollection<BooksAndGifts> BooksAndGifts { get; set; }
    }
}
