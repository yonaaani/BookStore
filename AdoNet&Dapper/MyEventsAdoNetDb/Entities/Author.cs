using Dapper_Example.DAL;
using System.Collections.Generic;

namespace MyEventsAdoNetDb.Entities
{
    public class Author
    {
        public Author()
        {

        }

        public Author(int idBook, string authorName, string aboutTheAuthor)
        {
            this.IDBook = idBook;
            this.AuthorName = authorName;
            this.AboutTheAuthor = aboutTheAuthor;
        }

        public int IDBook { get; set; }
        public string AuthorName { get; set; }
        public string AboutTheAuthor { get; set; }

        public virtual ICollection<BookList> BookList { get; set; }
    }
}