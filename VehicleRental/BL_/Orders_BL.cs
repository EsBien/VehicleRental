using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL_
{
    public class Orders_BL : IOrders_BL
    {
        IOrders_DL _orderDL;
        public Orders_BL(IOrders_DL orderDL)
        {
            _orderDL = orderDL;
        }

        public async Task deleteOrder(int myOrderId)
        {
           await _orderDL.deleteOrder(myOrderId);
        }

        public async Task<OrdersTbl> postOrder(OrdersTbl myOrder)
        {
            return await _orderDL.postOrder(myOrder);

        }
    }
}
