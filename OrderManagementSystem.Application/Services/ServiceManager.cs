using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IInvoiceService> _invoiceService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
            _orderService = new Lazy<IOrderService>(() => new OrderService(unitOfWork, mapper, emailService));
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(unitOfWork, mapper));
            _userService = new Lazy<IUserService>(() => new UserService(unitOfWork, mapper));
            _invoiceService = new Lazy<IInvoiceService>(() => new InvoiceService(unitOfWork, mapper));
        }

        public IProductService ProductService => _productService.Value;
        public IOrderService OrderService => _orderService.Value;
        public ICustomerService CustomerService => _customerService.Value;
        public IUserService UserService => _userService.Value;
        public IInvoiceService InvoiceService => _invoiceService.Value;
    }
}
