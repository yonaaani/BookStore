using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NlayerEF.DAL.Data
{
    internal class Context : DbContext
    {
    }
}

namespace TeamworkSystem.DataAccessLayer
{
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }

        public TeamworkSystemContext(DbContextOptions<TeamworkSystemContext> options)
            : base(options)
        {
        }
    }
}
