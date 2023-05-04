using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL_
{
    public interface IStation_BL
    {
        Task<List<StationTbl>> getStationByCity(string city);
    }
}