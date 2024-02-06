using Cocomix_API.DTO;
using Cocomix_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml;
using Cocomix_API.Helper;

namespace Cocomix_API.Service.ServiceIMPL
{
    public class OrderDetailServiceIMPL : OrderDetailsService
    {
        private readonly QLCHContext db;

        public OrderDetailServiceIMPL(QLCHContext context)
        {
            db = context;
        }

        public async Task<string> deleteOrderDetails(int orderID)
        {
            var orderDetail = await db.OrderDetails.FindAsync(orderID);
            if (orderDetail != null)
            {
                db.OrderDetails.Remove(orderDetail);
                await db.SaveChangesAsync();
                return "delete orderDetail success";
            }
            return null;
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            var orderDetail = await db.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                return orderDetail;
            }
            return null;
        }

        public async Task<List<OrderDetail>> GetListOrderDetailsByOrderID(int orderID)
        {
            var list_orderdetail = await db.OrderDetails
                                    .Include(od => od.Product)
                                    .Where(od => od.OrderId == orderID).ToListAsync();

            ConfigJsonSerializer configJsonSerializer = new ConfigJsonSerializer();
            configJsonSerializer.SerializeToJson(list_orderdetail);

            return list_orderdetail;
        }

        public async Task<OrderDetail> UpdateOderDetail(int id , OrderDetailsDTO orderDTO)
        {
            var orderDetail = await db.OrderDetails.FindAsync(id); 
            
            if (orderDetail != null) 
            {
                if (orderDTO.ProductId != null)
                {
                    var product = await db.Products.FindAsync(orderDTO.ProductId);
                    if (product != null)
                    {
                        orderDetail.Product = product;
                    }
                    else
                    {
                        orderDetail.Product = orderDetail.Product;
                        return null;
                    }
                        
                }

                orderDetail.TotalPrice = orderDTO.TotalPrice ?? orderDetail.TotalPrice;
                orderDetail.Quantity = orderDTO.Quantity ?? orderDetail.Quantity;
                await db.SaveChangesAsync();
                return orderDetail;
            }
            return null;
        }
    }
}
