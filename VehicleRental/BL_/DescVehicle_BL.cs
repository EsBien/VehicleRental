using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL_
{
    public class DescVehicle_BL : IDescVehicle_BL
    {
        IDescVehicle_DL _IDescVehicle_DL;
        public DescVehicle_BL(IDescVehicle_DL IDescVehicle_DL)
        {
            _IDescVehicle_DL = IDescVehicle_DL;
        }
        public async Task<DescVehicleTbl> getVehicle(int IdVehicle)
        {
            DescVehicleTbl Vehicle = await _IDescVehicle_DL.getVehicle(IdVehicle);
            if (Vehicle == null)
                return null;
            return Vehicle;
        }
        public async Task<List<DescVehicleTbl>> getVehicleByTypes(int IdVehicleType, int idStation, string city, int NumSeats
            , DateTime Production, decimal PricePerDay, decimal PricePerHour, string Company, string TrunckSize, bool GearBox)
        {
            var Vehicle = await _IDescVehicle_DL.getVehicleByTypes(IdVehicleType, idStation, city, NumSeats
            , Production, PricePerDay, PricePerHour, Company, TrunckSize, GearBox);
            if (Vehicle == null)
                return null;
            return Vehicle;
        }

        //public async Task<List<DescVehicleTbl>> getVehicleByType(int IdVehicleType)
        //{
        //    var Vehicle = await _IDescVehicle_DL.getVehicleByType(IdVehicleType);
        //    if (Vehicle == null)
        //        return null;
        //    return Vehicle;
        //}
        //public async Task<List<DescVehicleTbl>> getVehicleByStation(int idStation)
        //{
        //    var Vehicle = await _IDescVehicle_DL.getVehicleByStation(idStation);
        //    if (Vehicle == null)
        //        return null;
        //    return Vehicle;
        //}
        //public async Task<List<DescVehicleTbl>> getVehicleByCity(string city)
        //{
        //    var Vehicle = await _IDescVehicle_DL.getVehicleByCity(city);
        //    if (Vehicle == null)
        //        return null;
        //    return Vehicle;
        //}
    }
}
