namespace Cocomix_API.Service
{
    public interface OrderDetailsService
    {
        public Task<List<OrderDetailsService>> GetAll();
        public Task<OrderDetailsService> GetById(int id);
        public Task<List<OrderDetailsService>> GetOrderDetailsByOrderID(int orderID);
        public Task<OrderDetailsService> updateOderDetail(int id);
    }
}
