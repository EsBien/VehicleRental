using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstWebProject.Models
{
    public partial class OrdersTbl
    {
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int IdStation { get; set; }
        public int IdVehicle { get; set; }
        public int IdDesign { get; set; }
        public string IdCustomer { get; set; }
        public DateTime? OrderHour { get; set; }
        public DateTime? ReturnHour { get; set; }

        public virtual CustomerTbl IdCustomerNavigation { get; set; }
        public virtual DesignsTbl IdDesignNavigation { get; set; }
        public virtual StationTbl IdStationNavigation { get; set; }
        public virtual DescVehicleTbl IdVehicleNavigation { get; set; }
    }
}
