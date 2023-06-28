using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainPage.MVVM.Model;

namespace MainPage.MVVM.Model.Contracts
{
    public interface IBooksRepository
    {
        List<BookModel> GetAllBooks();
        //List<BookModel> GetBooksByAuthorId(int producerId);
        //List<BookModel> GetProductsByGenreId(int categoryId);
        //List<BookModel> GetProductsByProducerAndCategoryId(int producerId, int categoryId);
        //List<BookModel> GetProductsByPriceAsc(int producerId, int categoryId);
        //List<BookModel> GetProductsByPriceDesc(int producerId, int categoryId);
        BookModel GetBookById(int idBook);
        BookModel GetBookByName(string bookName);
        void AddNewBook(BookModel bookModel);
        void UpdateBook(BookModel changedBook);
        void DeleteBookById(int idBook);
        //void DeleteProductsByCategoryId(int categoryId);
        //void DeleteProductsByProducerId(int producerId);
    }
}
