using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Abstraction.Services
{
    public interface IServiceManager
    {
        ICustomerService CustomerService { get; }
        IOrderService OrderService { get; }
        IProductService ProductService { get; }
        IInvoiceService InvoiceService { get; }
        IUserService UserService { get; }
    }
}
