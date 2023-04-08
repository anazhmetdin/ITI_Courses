using Cars.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ILogger _logger;
        public static int RequestsCounter = 0;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Car>> Index()
        {
            _logger.LogInformation("Reading all cars");

            if (Car.Cars.Count == 0)
            {
                return NotFound();
            }

            return Car.Cars;
        }

        [HttpPost("v1")]
        public ActionResult Add_v1(Car car)
        {
            _logger.LogInformation("Adding a new car API v1");

            car.Type = "Gas";
            return _add(car);
        }

        [HttpGet]
        private ActionResult _add(Car car)
        {
            car.Id = Random.Shared.Next(1, 1000);

            Car.Cars.Add(car);

            return CreatedAtAction(
                actionName: nameof(Details),
                routeValues: new { car.Id },
                value: new { Message = "Car has been added successfully." }
            );
        }

        [HttpPost("v2")]
        [ServiceFilter(typeof(ValidateCarTypeAttribute))]
        public ActionResult Add_v2(Car car)
        {
            _logger.LogInformation("Adding a new car API v2");

            return _add(car);
        }

        [HttpGet("{Id}")]
        public ActionResult<Car> Details(int Id)
        {
            _logger.LogInformation($"Reading car details, Id = {Id}");

            Car? car = Car.Cars.Find(c => c.Id == Id);
            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        [HttpPut("v1/{Id}")]
        public ActionResult Update_v1(int Id, Car car)
        {
            _logger.LogInformation($"Updating car details API v1, Id = {Id}");
            car.Type = "Gas"; 
            return _update(Id, car);
        }

        [HttpPut("v2/{Id}")]
        [ServiceFilter(typeof(ValidateCarTypeAttribute))]
        public ActionResult Update_v2(int Id, Car car)
        {
            _logger.LogInformation($"Updating car details API v2, Id = {Id}");
            return _update(Id, car);
        }

        [NonAction]
        public ActionResult _update(int Id, Car car)
        {
            if (car == null || car.Id != Id)
            {
                return BadRequest();
            }

            Car? oldcar = Car.Cars.Find(c => c.Id == Id);
            if (car == null)
            {
                return NotFound();
            }

            Car.Cars.Remove(car);
            Car.Cars.Add(car);

            return NoContent();
        }

        [HttpGet("Hits")]
        public ActionResult<int> Hits() => RequestsCounter;

        [HttpDelete("{Id}")]
        public ActionResult<Car> Delete(int Id)
        {
            _logger.LogInformation($"Deleting car, Id = {Id}");

            Car? car = Car.Cars.Find(c => c.Id == Id);
            if (car == null)
            {
                return NotFound();
            }

            Car.Cars.Remove(car);

            return NoContent();
        }
    }
}
