using OrderManagementSystem.Application.Abstraction.Models.Customers;
using OrderManagementSystem.Application.Abstraction.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Abstraction.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto dto);
        Task<List<CustomerDto>> GetAllAsync();
        Task<List<OrderDto>> GetCustomerOrdersAsync(int customerId);
    }
}
