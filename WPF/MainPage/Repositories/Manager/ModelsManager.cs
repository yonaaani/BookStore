using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MainPage.MVVM.Model;

namespace MainPage.Repositories.Manager
{
    public partial class ModelsManager : DbContext
    {
        public ModelsManager() : base("name=ModelsManager") { }
        //public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<BookModel> Books { get; set; }
        public virtual DbSet<BookImageModel> BookImages { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }
        //public virtual DbSet<UserImage> UserImages { get; set; }
        //public virtual DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
