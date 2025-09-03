using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Client
    {

        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShippingAddres { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Active { get; set; } = true;
    }
}
