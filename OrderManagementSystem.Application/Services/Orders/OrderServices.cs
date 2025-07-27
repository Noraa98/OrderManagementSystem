using AutoMapper;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<OrderDto> CreateAsync(OrderCreateDto dto)
        {
            // Validate stock, calculate total, apply discount, update stock, generate invoice
            // Send email (can be implemented as separate methods for clean code)
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.UtcNow,
                PaymentMethod = dto.PaymentMethod,
                Status = "Pending"
            };

            order.OrderItems = dto.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                Discount = i.Discount
            }).ToList();

            order.TotalAmount = order.OrderItems.Sum(x => (x.UnitPrice - x.Discount) * x.Quantity);

            if (order.TotalAmount > 200)
                order.TotalAmount *= 0.9;
            else if (order.TotalAmount > 100)
                order.TotalAmount *= 0.95;

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveAsync();

            var invoice = new Invoice
            {
                OrderId = order.OrderId,
                InvoiceDate = DateTime.UtcNow,
                TotalAmount = order.TotalAmount
            };

            await _unitOfWork.Invoices.AddAsync(invoice);
            await _unitOfWork.SaveAsync();

            await _emailService.SendOrderConfirmationAsync(order.CustomerId, order.OrderId);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> UpdateStatusAsync(int orderId, string status)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null) return false;

            order.Status = status;
            _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveAsync();

            await _emailService.SendOrderStatusUpdateAsync(order.CustomerId, order.OrderId, status);
            return true;
        }
    }
}
