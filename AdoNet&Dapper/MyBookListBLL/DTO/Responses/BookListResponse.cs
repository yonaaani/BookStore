using MyBookListBLL.DTO;
using System.Collections.Generic;

namespace MyBookListBLL.Responses
{
    public class BookListResponse
    {
        public IEnumerable<BookListDTO> Books { get; set; }
    }
}
