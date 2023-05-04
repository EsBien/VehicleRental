using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_
{
    public class Rating_BL : IRating_BL
    {
        IRating_DL _rating_DL;
        public Rating_BL(IRating_DL rating_DL)
        {
            _rating_DL = rating_DL;
        }
        public async Task addRating(Rating rating)
        {
            await _rating_DL.addRating(rating);
        }
    }
}
