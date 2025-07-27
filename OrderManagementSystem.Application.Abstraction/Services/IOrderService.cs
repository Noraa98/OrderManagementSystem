using OrderManagementSystem.Application.Abstraction.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Abstraction.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderCreateDto dto);
        Task<OrderDto> GetByIdAsync(int id);
        Task<List<OrderDto>> GetAllAsync();
        Task<bool> UpdateStatusAsync(int id, string status);
    }
}
