using Dapper;
using Dapper_Example.DAL;
using MyEventsAdoNetDb.Entities;
using MyEventsAdoNetDb.Repositories.Contracts;
using MyEventsAdoNetDB.Repositories.Contracts;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsAdoNetDB.Repositories
{
    public class BookListRepository : GenericRepository<BookList>, IBookListRepository
    {
        public BookListRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "BookList")
        {
          
        }


    }
}
