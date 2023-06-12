using Domain.Common;
using System.Collections.Generic;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Author : BaseEntity
    {
        public string AuthorName { get; set; }
        public AboutTheAuthor AboutTheAuthor { get; set; } = default!; //value object

        public virtual ICollection<BooksAndAuthors> BooksAndAuthors { get; private set; } = default!; //many to many

        public Author()
        {
            BooksAndAuthors = new HashSet<BooksAndAuthors>();
        }
    }
}