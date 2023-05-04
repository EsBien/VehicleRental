using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DL;
namespace BL_
{
    public class Station_BL : IStation_BL
    {
        IStation_DL _StationDL;
        public Station_BL(IStation_DL StationDL)
        {
            _StationDL = StationDL;
        }
        public async Task<List<StationTbl>> getStationByCity(string city)
        {

            return await _StationDL.getStationByCity(city);
        }
    }
}
