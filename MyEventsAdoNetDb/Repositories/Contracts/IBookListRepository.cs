using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEventsAdoNetDb.Entities;
using Dapper_Example.DAL;
using MyEventsAdoNetDB.Repositories.Contracts;

namespace MyEventsAdoNetDb.Repositories.Contracts
{
    public interface IBookListRepository : IGenericRepository<BookList>
    { }
}
