using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IStation_DL
    {
        Task<List<StationTbl>> getStationByCity(string city);
    }
}