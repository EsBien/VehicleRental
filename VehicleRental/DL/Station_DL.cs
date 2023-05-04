using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class Station_DL : IStation_DL
    {
        VehicleRentals_dbContext _stationDL;
        public Station_DL(VehicleRentals_dbContext VehicleRental_dbContext)
        {
            _stationDL = VehicleRental_dbContext;
        }
        public async Task<List<StationTbl>> getStationByCity(string city)
        {
            var ListStation = await _stationDL.StationTbls.Where(s => s.City == city).ToListAsync();
            return ListStation;
        }
    }
}
