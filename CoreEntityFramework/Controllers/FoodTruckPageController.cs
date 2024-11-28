using Microsoft.AspNetCore.Mvc;
using PetAdoption.Interfaces;
using PetAdoption.Models;
using ErrorViewModel = PetAdoption.Models.ViewModels.ErrorViewModel;

namespace PetAdoption.Controllers
{
    public class FoodTruckPageController : Controller
    {
        private readonly IFoodTruckService _foodTruckService;

        // Dependency injection of the FoodTruck service
        public FoodTruckPageController(IFoodTruckService foodTruckService)
        {
            _foodTruckService = foodTruckService;
        }

        // Default action: redirect to list of food trucks
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: FoodTruckPage/List
        public async Task<IActionResult> List()
        {
            IEnumerable<FoodTruckDto?> foodTruckDtos = await _foodTruckService.ListFoodTrucks();
            return View(foodTruckDtos);
        }

        // GET: FoodTruckPage/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            FoodTruckDto? foodTruckDto = await _foodTruckService.FindFoodTruck(id);

            if (foodTruckDto == null)
            {
                return View("Error", new ErrorViewModel() { Errors = new List<string> { "Could not find food truck" } });
            }
            else
            {
                return View(foodTruckDto);
            }
        }

        // GET FoodTruckPage/New
        public ActionResult New()
        {
            return View();
        }

        // POST FoodTruckPage/Add
        [HttpPost]
        public async Task<IActionResult> Add(FoodTruckDto foodTruckDto)
        {
            ServiceResponse response = await _foodTruckService.AddFoodTruck(foodTruckDto);

            if (response.Status == ServiceResponse.ServiceStatus.Created)
            {
                return RedirectToAction("Details", "FoodTruckPage", new { id = response.CreatedId });
            }
            else
            {
                return View("Error", new ErrorViewModel() { Errors = response.Messages });
            }
        }

        // GET FoodTruckPage/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            FoodTruckDto? foodTruckDto = await _foodTruckService.FindFoodTruck(id);
            if (foodTruckDto == null)
            {
                return View("Error");
            }
            else
            {
                return View(foodTruckDto);
            }
        }

        // POST FoodTruckPage/Update/{id}
        [HttpPost]
        public async Task<IActionResult> Update(int id, FoodTruckDto foodTruckDto)
        {
            ServiceResponse response = await _foodTruckService.UpdateFoodTruck(id, foodTruckDto);

            if (response.Status == ServiceResponse.ServiceStatus.Updated)
            {
                return RedirectToAction("Details", "FoodTruckPage", new { id = id });
            }
            else
            {
                return View("Error", new ErrorViewModel() { Errors = response.Messages });
            }
        }


        // GET FoodTruckPage/ConfirmDelete/{id}
        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            FoodTruckDto? foodTruckDto = await _foodTruckService.FindFoodTruck(id);
            if (foodTruckDto == null)
            {
                return View("Error");
            }
            else
            {
                return View(foodTruckDto);
            }
        }

        // POST FoodTruckPage/Delete/{id}
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse response = await _foodTruckService.DeleteFoodTruck(id);

            if (response.Status == ServiceResponse.ServiceStatus.Deleted)
            {
                return RedirectToAction("List", "FoodTruckPage");
            }
            else
            {
                return View("Error", new ErrorViewModel() { Errors = response.Messages });
            }
        }
    }
}
