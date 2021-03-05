using hiTommy.Data.Services;
using hiTommy.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace hiTommy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get-all-customers")]
        public IActionResult GetAllShoes()
        {
            var allCustomers = _customerService.GetAllCustomers();
            return Ok(allCustomers);
        }

        [HttpGet("get-customer-by-id/{id}")]
        public IActionResult GetShoeById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpGet("get-customer-orders-by-customer-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _customerService.GetOrdersByCustomerId(id);
            return Ok(response);
        }

        [HttpPost("add-customer")]
        public IActionResult AddCustomer([FromBody] CustomerVm customer)
        {
            _customerService.AddCustomer(customer);
            return Ok();
        }

        [HttpPut("update-customer-by-id/{id}")]
        public IActionResult UpdateCustomerById(int id, [FromBody] CustomerVm customer)
        {
            var updatedShoe = _customerService.UpdateCustomerById(id, customer);
            return Ok(updatedShoe);
        }

        [HttpDelete("delete-customer-by-id/{id}")]
        public IActionResult DeleteShoeById(int id)
        {
            _customerService.DeleteCustomerById(id);
            return Ok();
        }
    }
}