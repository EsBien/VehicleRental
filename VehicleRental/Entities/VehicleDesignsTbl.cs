using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class VehicleDesignsTbl
    {
        public int IdVehicleDesign { get; set; }
        public int IdDesign { get; set; }
        public int IdVehicleType { get; set; }


        [JsonIgnore]
        public virtual DesignsTbl IdDesignNavigation { get; set; }

        [JsonIgnore]
        public virtual VehicleTypeTbl IdVehicleTypeNavigation { get; set; }
    }
}
