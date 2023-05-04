using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrders_DL
    {
        Task<OrdersTbl> postOrder(OrdersTbl myOrder);
        Task deleteOrder(int myOrderId);
    }
}