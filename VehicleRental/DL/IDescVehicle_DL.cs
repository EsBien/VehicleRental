using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IDescVehicle_DL
    {
        Task<DescVehicleTbl> getVehicle(int IdVehicle);

        Task<List<DescVehicleTbl>> getVehicleByTypes(int IdVehicleType, int idStation, string city, int NumSeats
            , DateTime Production, decimal PricePerDay, decimal PricePerHour, string Company, string TrunckSize, bool GearBox);
        //Task<List<DescVehicleTbl>> getVehicleByType(int IdVehicleType);
        // Task<List<DescVehicleTbl>> getVehicleByStation(int idStation);
        //Task<List<DescVehicleTbl>> getVehicleByCity(string city);
    }
}