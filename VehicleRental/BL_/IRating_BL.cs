using Entities;
using System.Threading.Tasks;

namespace BL_
{
    public interface IRating_BL
    {
        Task addRating(Rating rating);
    }
}