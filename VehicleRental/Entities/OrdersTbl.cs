using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
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
     
        public DateTime OrderHour { get; set; }
        public DateTime ReturnHour { get; set; }
        [JsonIgnore]
        public virtual CustomerTbl IdCustomerNavigation { get; set; }
        [JsonIgnore]
        public virtual DesignsTbl IdDesignNavigation { get; set; }
        [JsonIgnore]
        public virtual StationTbl IdStationNavigation { get; set; }
        [JsonIgnore]
        public virtual DescVehicleTbl IdVehicleNavigation { get; set; }
    }
}
