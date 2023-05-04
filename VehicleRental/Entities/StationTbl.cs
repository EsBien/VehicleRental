using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class StationTbl
    {
        public StationTbl()
        {
            OrdersTbls = new HashSet<OrdersTbl>();
        }

        public int IdStation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }

        public virtual ICollection<DescVehicleTbl> DescVehicleTbls { get; set; }
        public virtual ICollection<OrdersTbl> OrdersTbls { get; set; }
    }
}

