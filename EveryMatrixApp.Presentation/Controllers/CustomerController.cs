using EveryMatrix.Application.Interfaces;
using EveryMatrixApp.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EveryMatrixApp.Presentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();

            return View(customers);
        }

        public IActionResult Add()
        {
            var customerViewModel = new CustomerViewModel();
            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CustomerViewModel customerViewModel)
        {
            if(!ModelState.IsValid)
            {
                customerViewModel.IsValid = false;
                customerViewModel.Message = "Invalid input";
                return View(customerViewModel);
            }

            await _customerService.AddAsync(customerViewModel.CustomerDto);

            customerViewModel.IsSaved = true;
            customerViewModel.Message = "Customer is added to collection";
            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ObjectId customerId)
        {
            await _customerService.DeleteAsync(customerId);
            return RedirectToAction(nameof(GetAll));
        }
    }
}
