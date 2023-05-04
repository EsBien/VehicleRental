using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL_
{
    public interface IDesigns_BL
    {
        Task<DesignsTbl> GetDesign(int idDesign);
        Task<List<DesignsTbl>> getDesignByTyps(int IdVehicleType, string DescDesign, decimal DesignPrice);
    }
}