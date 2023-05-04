using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class VehicleTypeTbl
    {
        public VehicleTypeTbl()
        {
            DescVehicleTbls = new HashSet<DescVehicleTbl>();
            VehicleDesignsTbls = new HashSet<VehicleDesignsTbl>();
        }

        public int IdVehicleType { get; set; }
        public string VehicleType { get; set; }

        public virtual ICollection<DescVehicleTbl> DescVehicleTbls { get; set; }
        public virtual ICollection<VehicleDesignsTbl> VehicleDesignsTbls { get; set; }
    }
}
