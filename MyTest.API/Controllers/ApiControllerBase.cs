using MyTest.Infrastructure.Repositories;
using System.Web.Http;

namespace MyTest.API.Controllers
{
    public class ApiControllerBase: ApiController
    {
        public readonly ICarRepository _carRepository = null;
        public readonly IUserRepository _userRepository = null;
       public ApiControllerBase()
        {
            _carRepository = RepositoryFactory.CreateCarRepository();
            _userRepository = RepositoryFactory.CreateUserRepository();

        }
        public ApiControllerBase(ICarRepository carRepository)
        {          
            _carRepository = carRepository;
        }
        public ApiControllerBase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}