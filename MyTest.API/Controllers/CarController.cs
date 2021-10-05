using MyTest.API.Filters;
using MyTest.Core.Enitity;
using MyTest.Infrastructure.Repositories;
using System.Web.Http;
namespace MyTest.API.Controllers
{
    [TokenAuthenticationAttribute]
    [RoutePrefix("api/Car")]   
    public class CarController : ApiControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CarController()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="carRepository"></param>
        public CarController(ICarRepository carRepository) : base(carRepository)
        {

        }
        /// <summary>
        /// Get All Cars
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IHttpActionResult GetAll()
        {
            var car = _carRepository.GetAll();
            return Ok(car);
        }

        /// <summary>
        /// Search by year
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ByYear")]
        public IHttpActionResult GetByYear(string Year)
        {
            var car = _carRepository.SearchCarByYear(Year);
            return Ok(car);
        }

        /// <summary>
        /// Add new car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] Car car)
        {
            var bSuccess = _carRepository.AddCar(car);
            return Ok(bSuccess);
        }
        /// <summary>
        /// Update Car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public IHttpActionResult Put(Car car)
        {
            var bSuccess = _carRepository.UpdateCar(car);
            return Ok(bSuccess);
        }
    }
}