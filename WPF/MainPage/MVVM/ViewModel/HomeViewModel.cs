using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainPage.MVVM.Model;
using MainPage.Repositories;
using MainPage.Core;
using System.Collections.ObjectModel;

namespace MainPage.MVVM.ViewModel
{
    internal class HomeViewModel : ViewModelBase
    {
        //private UserModel _currentUser;
        //private readonly BooksRepository _booksRepository;
        //private readonly BookImagesRepository _bookImagesRepository;


        //public ObservableCollection<BookModel> Books { get; set; }

        //public HomeViewModel(UserModel currentUser, BooksRepository booksRepository, BookImagesRepository bookImagesRepository)
        //{
        //    _currentUser = currentUser;
        //    _booksRepository = booksRepository;
        //    _bookImagesRepository = bookImagesRepository;
        //    Books = new ObservableCollection<BookModel>();
        //}

        //private void LoadBooks()
        //{
        //    Books.Clear();
        //    var books = _booksRepository.GetAllBooks();
        //    foreach (var book in books)
        //    {
        //        Books.Add(book);
        //        var images = LoadImagesForBook(book.IDBook);
        //        if (images.Count > 0)
        //        {
        //            book.BookImageModel = images;
        //            // TODO
        //            book.ImageBytes = book.BookImageModel.ToList()[0].Image;
        //        }
        //        //string rateImageSource = "";
        //        //switch (book.Rating)
        //        //{
        //        //    case 0:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_0_of_5.png";
        //        //        break;
        //        //    case 0.5:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_0.5_of_5.png";
        //        //        break;
        //        //    case 1:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_1_of_5.png";
        //        //        break;
        //        //    case 1.5:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_1.5_of_5.png";
        //        //        break;
        //        //    case 2:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_2_of_5.png";
        //        //        break;
        //        //    case 2.5:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_2.5_of_5.png";
        //        //        break;
        //        //    case 3:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_3_of_5.png";
        //        //        break;
        //        //    case 3.5:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_3.5_of_5.png";
        //        //        break;
        //        //    case 4:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_4_of_5.png";
        //        //        break;
        //        //    case 4.5:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_4.5_of_5.png";
        //        //        break;
        //        //    case 5:
        //        //        rateImageSource = "/Images/StarRates/Star_rating_5_of_5.png";
        //        //        break;
        //        //}
        //       // book.CurrentRateSource = rateImageSource;
        //    }
        //}

        //    private List<BookImageModel> LoadImagesForBook(int idBook)
        //    {
        //        return _bookImagesRepository.GetImagesByBookId(idBook).ToList();
        //    }

        }
    }

