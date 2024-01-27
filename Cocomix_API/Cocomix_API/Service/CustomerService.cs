using Cocomix_API.DataReponse;
using Cocomix_API.DTO;

namespace Cocomix_API.Service
{
    public interface CustomerService
    {
        public Task<List<CustomerReponse>> GetAllCustomer();
        public Task<CustomerReponse> GetCustomerByID(int id);
        public Task<CustomerReponse> AddCustomer(CustomerDTO customerDTO);
        public Task<CustomerReponse> UpdateCustomer(int id , CustomerDTO customerDTO);
        public Task<string> DeleteCustomer(int id);
    }
}
