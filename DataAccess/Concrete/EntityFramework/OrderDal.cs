using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderDal : EfEntityRepositoryBase<Order, ShopDbContext>, IOrderDal
    {
        public List<OrderDTO> GetUserOrders(int userId)
        {
            using var context = new ShopDbContext();
            var orderList = context.Order.Include(x=>x.Product).Include(x=>x.OrderTracking).Where(x=>x.K205UserId == userId).ToList();

            List<OrderDTO> list = new();

            foreach (var orders in orderList)
            {
                OrderDTO orderDTO = new()
                {
                    K205UserId = userId,
                    Id = orders.Id,
                    IsDelivered = orders.IsDelivered,
                    ProductName = orders.Product.Name,
                    SKU = orders.Product.SKU,
                    Status  = orders.OrderTracking.Name,
                    TotalPrice = orders.TotalPrice,
                    TotalQuantity = orders.TotalQuantity,
                    OrderTrackingId = orders.OrderTrackingId
                };
                list.Add(orderDTO);
            }


            return list;
        }
    }
}
