using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Controllers.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Controllers.Controllers.Products
{
    [Authorize(Roles = "Admin")]
    public class InvoiceController : BaseApiController
    {
        // GET: /api/invoices
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            // TODO: Return all invoices
            return Ok("All invoices");
        }

        // GET: /api/invoices/{invoiceId}
        [HttpGet("{invoiceId}")]
        public IActionResult GetInvoiceById(int invoiceId)
        {
            // TODO: Return invoice by ID
            return Ok($"Invoice details for {invoiceId}");
        }
    }
    }
