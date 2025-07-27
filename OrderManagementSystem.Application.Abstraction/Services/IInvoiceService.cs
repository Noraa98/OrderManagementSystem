using OrderManagementSystem.Application.Abstraction.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.Abstraction.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> GetByIdAsync(int id);
        Task<List<InvoiceDto>> GetAllAsync();
    }
}
