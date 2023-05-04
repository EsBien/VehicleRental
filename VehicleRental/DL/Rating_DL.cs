using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Rating_DL : IRating_DL
    {
        VehicleRentals_dbContext _myVehicleRental_dbContext;
        public Rating_DL(VehicleRentals_dbContext myVehicleRental_dbContext)
        {
            _myVehicleRental_dbContext = myVehicleRental_dbContext;
        }
        public async Task addRating(Rating rating)
        {
            await _myVehicleRental_dbContext.AddAsync(rating);
            await _myVehicleRental_dbContext.SaveChangesAsync();
        }
    }
}
