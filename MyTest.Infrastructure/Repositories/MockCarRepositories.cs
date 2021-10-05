using MyTest.Core.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTest.Infrastructure.Repositories
{  
    public class MockCarRepositories : ICarRepository
    {
       public static  List<Car> _cars = new List<Car>
        {
            {new Car{ Id = 1,Name="Mercedes-Benz", Model="A-Class", Year ="2022" } },
            {new Car{ Id = 2,Name="Audi", Model="A6", Year ="2020" } },
            {new Car{ Id = 3,Name="Tesla", Model="Cybertruck", Year ="2021" } },
            {new Car{ Id = 4,Name="Ford", Model="Fusion", Year ="2018" } },
            {new Car{ Id = 5,Name="BMW", Model="iX", Year ="2022" } }
        };

        public Car AddCar(Car car)
        {
            if (car != null && !String.IsNullOrEmpty(car.Name) && !String.IsNullOrEmpty(car.Model) && !String.IsNullOrEmpty(car.Year))
            {
                car.Id = _cars.Count + 1;
                _cars.Add(car);               
            }
            return _cars.Where(s => s.Name == car.Name && s.Model == car.Model && s.Year == car.Year).FirstOrDefault();
       
        }

        public Car DeleteCar(Car car)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            return _cars.ToList();
        }

        public IEnumerable<Car> SearchCarByYear(string Year)
        {
            return _cars.Where(s => s.Year == Year).ToList();
        }

        public Car UpdateCar(Car car)
        {
            var c = _cars.Where(s => s.Id == car.Id).FirstOrDefault();
            if (c != null)
            {
                c.Model = car.Model;
                c.Name = car.Name;
                c.Year = car.Year;                
            }
            return c;
        }
        
    }
}
