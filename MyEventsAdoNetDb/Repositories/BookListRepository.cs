using Dapper;
using Dapper_Example.DAL;
using MyEventsAdoNetDb.Entities;
using MyEventsAdoNetDb.Repositories.Contracts;
using MyEventsAdoNetDB.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEventsAdoNetDB.Repositories
{

    //Пошук книги за назвою
    public class BookListRepository : GenericRepository<BookList>, IBookListRepository
    {
        public BookListRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction, string tableName)
            : base(sqlConnection, dbTransaction, tableName)
        {
        }

        public async Task<IEnumerable<BookList>> SearchBookNameTypeAsync(string bookName)
        {
            var query = $"SELECT * FROM BookList WHERE BookName LIKE @BookName";
            var result = await _sqlConnection.QueryAsync<BookList>(query,
                new { BookName = $"%{bookName}%" },
                transaction: _dbTransaction);
            return result;
        }


        //Пошук книги за автором
        public async Task<IEnumerable<BookList>> GetByAuthorAsync(string authorName)
        {
            
                var sql = @"SELECT * FROM BookList
                        INNER JOIN Author ON BookList.IDAuthor = Author.ID
                        WHERE Author.AuthorName = @AuthorName";
                var parameters = new { AuthorName = authorName };
                var result = await _sqlConnection.QueryAsync<BookList, Author, BookList>(
                    sql,
                    (book, author) =>
                    {
                        book.Author = author;
                        return book;
                    },
                    parameters,
                    splitOn: "ID,IDAuthor"
                );
                return result;
            
        }

        //Сортування книг за жанром
        public async Task<IEnumerable<BookList>> GetByGenreAsync(string genre)
        {
            var sql = @"SELECT * FROM BookList WHERE BookType = @Genre ORDER BY BookName ASC";
            var parameters = new { Genre = genre };
            var result = await _sqlConnection.QueryAsync<BookList>(sql, parameters);
            return result;
        }
    }
}

