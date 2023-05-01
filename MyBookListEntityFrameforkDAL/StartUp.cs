using MyBookListEntityFrameworkDAL.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyBookListEntityFrameworkDAL
{
    public class StartUp
    {
        public static void Main()
        {
            using (EventsContext context = new EventsContext())
            {
                context.Database.CanConnect();
            }
        }
    }
}
