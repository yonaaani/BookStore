using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Orders : BaseEntity
    {
        public string OrderName { get; set; } = default!;

        public Orders(int id, string orderName)
        {
            Id = id;
            OrderName = orderName;
        }
    }
}
