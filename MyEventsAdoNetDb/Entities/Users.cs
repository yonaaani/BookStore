
using Dapper_Example.DAL;
using System.Collections.Generic;

namespace MyEventsAdoNetDb.Entities
{
    public class Users
    {
        public Users()
        {

        }

        public Users(string userName, string userNickname, string userEmail, int password)
        {
            this.UserName = userName;
            this.UserNickname = userNickname;
            this.UserEmail = userEmail;
            this.Password = password;
        }

        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }
        public int Password { get; set; }
        public virtual ICollection<BookList> BookList { get; set; }
        public virtual ICollection<Gifts> Gifts { get; set; }
    }
}