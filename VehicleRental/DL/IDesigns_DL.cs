using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IDesigns_DL
    {
        Task<DesignsTbl> getDesign(int idDesign);
        Task<List<DesignsTbl>> getDesignByTyps(int IdVehicleType, string DescDesign, decimal DesignPrice);
    }
}