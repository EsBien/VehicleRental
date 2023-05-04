using Entities;
using System.Threading.Tasks;

namespace BL_
{
    public interface IOrders_BL
    {
        Task<OrdersTbl> postOrder(OrdersTbl myOrder);
        Task deleteOrder(int myOrderId);
    }
}