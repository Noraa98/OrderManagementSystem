using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Controllers.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Controllers.Controllers.Customers
{
    [Authorize(Roles = "Customer,Admin")]
    public class CustomerController : BaseApiController
    {
        // POST: /api/customers
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateCustomer()
        {
            // TODO: Implement logic to create a new customer
            return Ok("Customer created");
        }

        // GET: /api/customers/{customerId}/orders
        [HttpGet("{customerId}/orders")]
        public IActionResult GetCustomerOrders(int customerId)
        {
            // TODO: Implement logic to retrieve all orders for the given customer
            return Ok($"Orders for customer {customerId}");
        }
    }
    }
