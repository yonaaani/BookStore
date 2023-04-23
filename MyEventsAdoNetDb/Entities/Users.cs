using Dapper_Example.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEventsAdoNetDb.Entities
{
    public class Users : BaseEntity
    {
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }
        public int Password { get; set; }
        public virtual ICollection<BookList> BookList { get; set; }
        public virtual ICollection<Gifts> Gifts { get; set; }
    }
}
