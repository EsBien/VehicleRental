using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrdersDL : IOrders_DL
    {


        VehicleRentals_dbContext _OrdersDL;
        public OrdersDL(VehicleRentals_dbContext VehicleRental_dbContext)
        {
            _OrdersDL = VehicleRental_dbContext;
        }

        public async Task<OrdersTbl> postOrder(OrdersTbl myOrder)
        {
            await _OrdersDL.OrdersTbls.AddAsync(myOrder);
             await _OrdersDL.SaveChangesAsync();
            return _OrdersDL.OrdersTbls.Include(o => o.IdStationNavigation).Where(o=>o.IdStation==myOrder.IdStation).FirstOrDefault();
             //return myOrder;
        }
        public async Task deleteOrder(int myOrderId)
        {
         
            OrdersTbl deleteOrder = _OrdersDL.OrdersTbls.Where(o => o.IdOrder == myOrderId)
                .FirstOrDefault();
             _OrdersDL.OrdersTbls.Remove(deleteOrder);
            await _OrdersDL.SaveChangesAsync();
        }
    }
}
