using MyTest.Core.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Infrastructure.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();       
        IEnumerable<Car> SearchCarByYear(string Year);
        Car UpdateCar(Car car);
        Car AddCar(Car car);
        Car DeleteCar(Car car);

    }
}
