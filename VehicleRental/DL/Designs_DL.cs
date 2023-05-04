using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{

    public class Designs_DL : IDesigns_DL
    {
        VehicleRentals_dbContext _VehicleRental_dbContext;
        public Designs_DL(VehicleRentals_dbContext VehicleRental_dbContext)
        {
            _VehicleRental_dbContext = VehicleRental_dbContext;
        }
        public async Task<DesignsTbl> getDesign(int idDesign)
        {
            return await _VehicleRental_dbContext.DesignsTbls.FindAsync(idDesign);
        }
        public async Task<List<DesignsTbl>> getDesignByTyps(int IdVehicleType, string DescDesign, decimal DesignPrice)
        {
             var listDesign = await _VehicleRental_dbContext.DesignsTbls.Include(o => o.VehicleDesignsTbls).ToListAsync();
            if (IdVehicleType != 0)
            {
                listDesign = listDesign.Where(o => o.VehicleDesignsTbls.FirstOrDefault().IdVehicleType == IdVehicleType).ToList();
            
                if (DescDesign != null)
                {
                      listDesign = listDesign.Where(o => o.VehicleDesignsTbls.FirstOrDefault().IdVehicleType == IdVehicleType
                    && o.DescDesign == DescDesign).ToList();
                }
                if (DesignPrice != 0)
                {
                    listDesign = listDesign.Where(o => o.VehicleDesignsTbls.FirstOrDefault().IdVehicleType == IdVehicleType
                   && o.DesignPrice > DesignPrice).ToList();
                }
            }
            if (DescDesign != null)
            {
                listDesign = listDesign.Where(o =>  o.DescDesign == DescDesign).ToList();
            }
            if (DesignPrice != 0)
            {
                listDesign = listDesign.Where(o =>  o.DesignPrice < DesignPrice).ToList();
            }



            return listDesign;
        }
    }
}
