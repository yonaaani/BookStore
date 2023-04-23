using Dapper_Example.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDb.Entities
{
    public class Author : BaseEntity
    {
        public int IDBook { get; set; }
        public string AuthorName { get; set; }
        public string AboutTheAuthor { get; set; }

        public virtual ICollection<BookList> BookList { get; set; }
    }
}
