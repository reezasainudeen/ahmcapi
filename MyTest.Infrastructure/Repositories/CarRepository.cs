using MyTest.Core.Enitity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyTest.Infrastructure.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }
        /// <summary>
        /// Gat all Cars
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Car> GetAll()
        {
            return All();
        }
        /// <summary>
        /// Search by year
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        public IEnumerable<Car> SearchCarByYear(string Year)
        {
            return context.Cars
                 .Where(c => c.Year == Year)
                 .ToList();
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Car UpdateCar(Car entity)
        {
            var car = context.Cars
                .Single(c => c.Id == entity.Id);

            car.Name = entity.Name;
            car.Model = entity.Model;
            car.Year = entity.Year;
            return base.Update(car);
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public Car AddCar(Car car)
        {
            base.SaveChanges();
            return context.Cars
                 .Where(c => c.Name == car.Name && c.Model == car.Model && c.Year == car.Year)
                 .FirstOrDefault();
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public Car DeleteCar(Car car)
        {
            throw new NotImplementedException();
        }    

    }
   
}
