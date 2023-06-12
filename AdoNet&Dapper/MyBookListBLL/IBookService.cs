using MyBookListBLL.Services;
using MyBookListBLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookListBLL.Requests;

namespace MyBookListBLL.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookListDTO>> GetAllAsync();
        Task<BookListDTO> GetByIdAsync(int id);
        Task<IEnumerable<BookListDTO>> GetByAuthorAsync(string authorName);
        Task<IEnumerable<BookListDTO>> GetByGenreAsync(string genre);
        Task<BookListDTO> AddAsync(BookListDTO bookDTO);
        Task DeleteAsync(int id);
        Task<BookListDTO> UpdateAsync(int id, UpdateBookRequest request);

    }
}
