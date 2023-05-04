using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstWebProject.Models2
{
    public partial class VehicleDesignsTbl
    {
        public int IdVehicleDesign { get; set; }
        public int IdDesign { get; set; }
        public int IdVehicleType { get; set; }

        public virtual DesignsTbl IdDesignNavigation { get; set; }
        public virtual VehicleTypeTbl IdVehicleTypeNavigation { get; set; }
    }
}
