using AutoMapper;
using Cocomix_API.DataReponse;
using Cocomix_API.DTO;
using Cocomix_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cocomix_API.Service.ServiceIMPL
{
    public class CustomerServiceIMPL : CustomerService
    {
        private readonly QLCHContext db;
        private readonly IMapper map;

        public CustomerServiceIMPL(QLCHContext context , IMapper mapper) 
        {
            db = context;
            map = mapper;
        }

        public async Task<CustomerReponse> AddCustomer(CustomerDTO customerDTO)
        {
            var customer = map.Map<Customer>(customerDTO);
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return map.Map<CustomerReponse>(customer);
        }

        public async Task<string> DeleteCustomer(int id)
        {
            var customer = await db.Customers.FindAsync(id);
            if (customer != null) 
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
                return "delete customer success";
            }
            return null;
        }

        public async Task<List<CustomerReponse>> GetAllCustomer()
        {
            var list_cutomer = await db.Customers.ToListAsync();
            return map.Map<List<CustomerReponse>>(list_cutomer);
        }

        public async Task<CustomerReponse> GetCustomerByID(int id)
        {
            var customer = await db.Customers.FindAsync(id);
            if(customer != null)
            {
                return map.Map<CustomerReponse>(customer);
            }
            return null;
        }

        public async Task<CustomerReponse> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            var customer_old = await db.Customers.FindAsync(id);
            if( customer_old != null )
            {
                map.Map(customerDTO , customer_old );
                await db.SaveChangesAsync();
                return map.Map<CustomerReponse>(customer_old);
            }
            return null;
        }
    }
}
