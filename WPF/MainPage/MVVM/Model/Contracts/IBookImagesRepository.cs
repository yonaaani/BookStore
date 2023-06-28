using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage.MVVM.Model.Contracts
{
    public interface IBookImagesRepository
    {
        IEnumerable<BookImageModel> GetImagesByBookId(int idBook);
    }
}
