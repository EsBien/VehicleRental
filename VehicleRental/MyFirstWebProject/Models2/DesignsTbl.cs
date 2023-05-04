using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstWebProject.Models2
{
    public partial class DesignsTbl
    {
        public DesignsTbl()
        {
            OrdersTbls = new HashSet<OrdersTbl>();
            VehicleDesignsTbls = new HashSet<VehicleDesignsTbl>();
        }

        public int IdDesign { get; set; }
        public string DescDesign { get; set; }
        public decimal DesignPrice { get; set; }

        public virtual ICollection<OrdersTbl> OrdersTbls { get; set; }
        public virtual ICollection<VehicleDesignsTbl> VehicleDesignsTbls { get; set; }
    }
}
