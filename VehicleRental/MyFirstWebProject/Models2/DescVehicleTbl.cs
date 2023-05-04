using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstWebProject.Models2
{
    public partial class DescVehicleTbl
    {
        public DescVehicleTbl()
        {
            OrdersTbls = new HashSet<OrdersTbl>();
        }

        public int IdVehicle { get; set; }
        public int? IdVehicleType { get; set; }
        public int? IdStation { get; set; }
        public byte NumSeats { get; set; }
        public DateTime Production { get; set; }
        public decimal? PricePerDay { get; set; }
        public decimal? PricePerHour { get; set; }
        public string Company { get; set; }
        public string TrunckSize { get; set; }
        public bool GearBox { get; set; }

        public virtual StationTbl IdStationNavigation { get; set; }
        public virtual VehicleTypeTbl IdVehicleTypeNavigation { get; set; }
        public virtual ICollection<OrdersTbl> OrdersTbls { get; set; }
    }
}
