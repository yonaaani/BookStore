using MyEventsAdoNetDb.Entities;

namespace Dapper_Example.DAL
{
    public class BookList : BaseEntity
    {
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string Overview { get; set; }
        public double Rating { get; set; }
        public int Price { get; set; }

        public bool OnCard { get; set; }
        public bool OnHeart { get; set; }

        public int IDAuthor { get; set; }
        public Author Author { get; set; }
        public int IDUser { get; set; }
        public Users Users { get; set; }

        public virtual ICollection<BooksAndGifts> BooksAndGifts { get; set; }
    }
}
