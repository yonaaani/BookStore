using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookListEntityFrameworkDataAccessLayer
{
    public class StartUp
    {
        public static void Main()
        {
            using (HospitalContext context = new HospitalContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
