using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IRating_DL
    {
        Task addRating(Rating rating);
    }
}