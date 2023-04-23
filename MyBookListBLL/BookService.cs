using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper_Example.DAL;
using Microsoft.EntityFrameworkCore;
using MyBookListBLL.DTO;
using MyBookListBLL.Requests;
using MyEventsAdoNetDb.Entities;
using MyEventsAdoNetDb.Repositories.Contracts;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Contracts;

namespace MyBookListBLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookListDTO>> GetAllAsync()
        {
            var books = await _unitOfWork._booklistRepository.GetAllAsync();
            var bookDTOs = _mapper.Map<IEnumerable<BookListDTO>>(books);
            return bookDTOs;
        }

        public async Task<BookListDTO> GetByIdAsync(int id)
        {
            var book = await _unitOfWork._booklistRepository.GetAsync(id);
            var bookDTO = _mapper.Map<BookListDTO>(book);
            return bookDTO;
        }

        public async Task<IEnumerable<BookListDTO>> GetByAuthorAsync(string authorName)
        {
            var books = await _unitOfWork._booklistRepository.GetByAuthorAsync(authorName);
            var bookDTOs = _mapper.Map<IEnumerable<BookListDTO>>(books);
            return bookDTOs;
        }

        public async Task<IEnumerable<BookListDTO>> GetByGenreAsync(string genre)
        {
            var books = await _unitOfWork._booklistRepository.GetByGenreAsync(genre);
            var bookDTOs = _mapper.Map<IEnumerable<BookListDTO>>(books);
            return bookDTOs;
        }

        public async Task<BookListDTO> AddAsync(BookListDTO bookDTO)
        {
            var book = _mapper.Map<BookList>(bookDTO);
            var addedBook = await _unitOfWork._booklistRepository.AddAsync(book);
            var addedBookDTO = _mapper.Map<BookListDTO>(addedBook);
            return addedBookDTO;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork._booklistRepository.DeleteAsync(id);
        }


        public async Task<BookListDTO> UpdateAsync(int id, UpdateBookRequest request)
        {
            var existingBook = await _unitOfWork._booklistRepository.GetAsync(id);

            if (existingBook == null)
            {
                return null;
            }

            _mapper.Map(request, existingBook);

            await _unitOfWork._booklistRepository.UpdateAsync(existingBook);
            await _unitOfWork._booklistRepository.SaveChangesAsync();

            var updatedBookDTO = _mapper.Map<BookListDTO>(existingBook);

            return updatedBookDTO;
        }





    }
}