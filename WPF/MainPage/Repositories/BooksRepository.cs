using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainPage.Repositories.Manager;
using MainPage.MVVM.Model.Contracts;
using MainPage.MVVM.Model;
using System.Data.Entity;
using System.Windows.Forms;

namespace MainPage.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ModelsManager _dbManager;
        public BooksRepository()
        {
            _dbManager = new ModelsManager();
        }
        public void AddNewBook(BookModel book)
        {
            _dbManager.Books.Add(book);
            _dbManager.SaveChanges();
        }

        public void DeleteBookById(int idBook)
        {
            _dbManager.Books.Remove(GetBookById(idBook));
            _dbManager.SaveChanges();
        }

        //public void DeleteProductsByCategoryId(int categoryId)
        //{
        //    var products = _dbManager.Products.Where(p => p.Producer.CategoryId == categoryId).ToList();
        //    foreach (var product in products)
        //    {
        //        var images = _dbManager.ProductImages
        //            .Where(image => image.ProductId == product.Id).ToList();
        //        if (images != null)
        //        {
        //            foreach (var img in images)
        //                _dbManager.ProductImages.Remove(img);
        //        }
        //        _dbManager.Products.Remove(product);
        //    }
        //    _dbManager.SaveChanges();
        //}

        //public void DeleteProductsByProducerId(int producerId)
        //{
        //    var products = _dbManager.Products.Where(p => p.ProducerId == producerId).ToList();
        //    foreach (var product in products)
        //    {
        //        var images = _dbManager.ProductImages
        //            .Where(image => image.ProductId == product.Id).ToList();
        //        if (images != null)
        //        {
        //            foreach (var img in images)
        //                _dbManager.ProductImages.Remove(img);
        //        }
        //        _dbManager.Products.Remove(product);
        //    }
        //    _dbManager.SaveChanges();
        //}

        public List<BookModel> GetAllBooks()
        {
            return _dbManager.Books.ToList();
        }

        public BookModel GetBookById(int idBook)
        {
            return _dbManager.Books.Find(idBook);
        }

        public BookModel GetBookByName(string bookName)
        {
            return _dbManager.Books.Where(p => p.BookName.Equals(bookName)).FirstOrDefault();
        }

        //public List<Product> GetProductsByCategoryId(int categoryId)
        //{
        //    return _dbManager.Products.Where(_p => _p.Producer.CategoryId == categoryId)?.ToList();
        //}

        //public List<Product> GetProductsByPriceAsc(int producerId, int categoryId)
        //{
        //    return _dbManager.Products.Where(p => p.ProducerId == producerId && p.Producer.CategoryId == categoryId).OrderBy(p => p.Price).ToList();
        //}

        //public List<Product> GetProductsByPriceDesc(int producerId, int categoryId)
        //{
        //    return _dbManager.Products.Where(p => p.ProducerId == producerId && p.Producer.CategoryId == categoryId).OrderByDescending(p => p.Price).ToList();
        //}

        //public List<Product> GetProductsByProducerAndCategoryId(int producerId, int categoryId)
        //{
        //    return _dbManager.Products.Where(p => p.ProducerId == producerId && p.Producer.CategoryId == categoryId).ToList();
        //}

        //public List<Product> GetProductsByProducerId(int producerId)
        //{
        //    return _dbManager.Products.Where(p => p.ProducerId == producerId).ToList();
        //}

        public void UpdateBook(BookModel changedBook)
        {
            var book = _dbManager.Books.Find(changedBook.IDBook);
            book.BookName = changedBook.BookName;
            book.BookType = changedBook.BookType;
            book.Overview = changedBook.Overview;
            book.Rating = changedBook.Rating;
            book.Price = changedBook.Price;
            _dbManager.Entry(book).State = EntityState.Modified;
            _dbManager.SaveChanges();
        }
    }
}
