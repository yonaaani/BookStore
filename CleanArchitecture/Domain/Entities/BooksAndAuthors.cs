using Domain.Common;

namespace Domain.Entities
{
    public class BooksAndAuthors : BaseEntity // many-to-many
    {
        public int IDBook { get; set; }
        public BookList BookList { get; set; } = default!;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = default!;
    }
}