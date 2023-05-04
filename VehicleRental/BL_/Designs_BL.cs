using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BL_
{
    public class Designs_BL : IDesigns_BL
    {
        IDesigns_DL _IDesigns_DL;
        public Designs_BL(IDesigns_DL IDesigns_DL)
        {
            _IDesigns_DL = IDesigns_DL;
        }
        public async Task<DesignsTbl> GetDesign(int idDesign)
        {
            return await _IDesigns_DL.getDesign(idDesign);
        }
        public async Task<List<DesignsTbl>> getDesignByTyps(int IdVehicleType, string DescDesign, decimal DesignPrice)
        {
            return await _IDesigns_DL.getDesignByTyps(IdVehicleType, DescDesign, DesignPrice);
        }

    }
}
