using AutoMapper;
using Cocomix_API.DTO;
using Cocomix_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Cocomix_API.Service.ServiceIMPL
{
    public class OrderServiceIMPL : OrderService
    {
        private readonly QLCHContext db;
        private readonly IMapper map;

        public OrderServiceIMPL(QLCHContext context , IMapper mapper) 
        {
            db = context;
            map = mapper;
        }

        public async Task<Order> addOrder(OrderDTO orderDTO)
        {

            var newOrder = map.Map<Order>(orderDTO);
            db.Orders.Add(newOrder);
            await db.SaveChangesAsync();

            decimal total_price = 0;
            var total_product = 0;

            foreach (ProductOrder product_order in orderDTO.Product)
            {
                var product = await db.Products.FindAsync(product_order.ProductId);
                if(product != null) 
                {
                    decimal? price = product_order.quantity * product.Price;
                    var orderDetail = new OrderDetail()
                    {
                        ProductId = product_order.ProductId,
                        OrderId = newOrder.OrderId,
                        Quantity = product_order.quantity,
                        TotalPrice = price.HasValue ? price.Value : 0
                    };
                    db.OrderDetails.Add(orderDetail);
                    
                    //Tính tổng số sản phẩm và tổng giá tiền
                    total_product++;
                    total_price += price.HasValue ? price.Value : 0;
                }
            }

            //Cập nhật lại order
            newOrder.TotalPrice = total_price;
            newOrder.TotalProduct = total_product;
            newOrder.OrderDate = DateTime.Now;
            await db.SaveChangesAsync();

            return newOrder;
        }

        public async Task<string> deleteOrder(int id)
        {
            var order = await db.Orders.FindAsync(id);
            if (order != null)
            {
                db.Remove(order);
                await db.SaveChangesAsync();
                return "Delete Order Success";
            }
            return null;
        }

        public async Task<List<Order>> getListOrder()
        {
            var list_order = await db.Orders.ToListAsync();
            return list_order;
        }

        public async Task<Order> getOrderById(int id)
        {
            var order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<Order> updateOrder(int id, DataOrderDTO dataOrderDTO)
        {
            var order = await db.Orders.FindAsync(id);
            if(order != null)
            {
                order.Note = dataOrderDTO.Note ?? order.Note;
                order.Status = dataOrderDTO.Status ?? order.Status;
                order.TotalProduct = dataOrderDTO.TotalProduct ?? order.TotalProduct;
                order.TotalPrice = dataOrderDTO.TotalPrice ?? order.TotalPrice;
                order.OrderDate = dataOrderDTO.OrderDate ?? order.OrderDate;
                await db.SaveChangesAsync();
                return order;
            }
            return null;
        }
    }
}
