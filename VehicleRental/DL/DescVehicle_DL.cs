using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace DL
{
    public class DescVehicle_DL : IDescVehicle_DL
    {


        VehicleRentals_dbContext _VehicleRental;
        public DescVehicle_DL(VehicleRentals_dbContext VehicleRental_dbContext)
        {
            _VehicleRental = VehicleRental_dbContext;
        }
        public async Task<DescVehicleTbl> getVehicle(int IdVehicle)
        {

            DescVehicleTbl DescVehicle = await _VehicleRental.DescVehicleTbls.FindAsync(IdVehicle);
            if (DescVehicle != null)
                return DescVehicle;
            return null;
        }

        public async Task<List<DescVehicleTbl>> getVehicleByTypes(int IdVehicleType, int idStation, string city,int NumSeats
            , DateTime Production, decimal PricePerDay, decimal PricePerHour, string Company, string TrunckSize, bool GearBox)
        {
          
            var listVehicle =await _VehicleRental.DescVehicleTbls.Include(s => s.IdStationNavigation).Include(v=>v.IdVehicleTypeNavigation).ToListAsync();

            if (IdVehicleType!=0)
            {
                 listVehicle = listVehicle.Where(t => t.IdVehicleType == IdVehicleType).ToList();
            }
            if(idStation!=0)
            {
                listVehicle = listVehicle.Where(t => t.IdStation == idStation).ToList();
            }
            if(city!=null)
            {
                listVehicle = listVehicle.Where(c => c.IdStationNavigation.City == city).ToList();
            }
            if(NumSeats!=0)
            {
                listVehicle = listVehicle.Where(n => n.NumSeats == NumSeats).ToList();
            }
            if(Production!=default)
            {
               
                listVehicle =  listVehicle.Where(n => n.Production == Production).ToList();
            }
            if (PricePerDay != 0)
            {
                listVehicle =  listVehicle.Where(n => n.PricePerDay == PricePerDay).ToList();
            }
            if (PricePerHour != 0)
            {
                listVehicle =  listVehicle.Where(n => n.PricePerHour == PricePerHour).ToList();
            }
            if (Company != null)
            {
                listVehicle =  listVehicle.Where(n => n.Company == Company).ToList();
            }
            if (TrunckSize != null)
            {
                listVehicle =  listVehicle.Where(n => n.TrunckSize == TrunckSize).ToList();
            }
            //if (GearBox != null)
            //{
            //    listVehicle = await _VehicleRental.DescVehicleTbls.Where(n => n.GearBox == GearBox).ToListAsync();
            //}
            return listVehicle;
        }




     
       
    }
}
