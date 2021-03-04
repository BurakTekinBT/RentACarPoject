using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>() {

            new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 1993, DailyPrice = 100000, Description = "Ferrari" },
            new Car { Id = 2, BrandId = 3, ColorId = 6, ModelYear = 2000, DailyPrice = 2000, Description = "Porshe" },
            new Car { Id = 3, BrandId = 3, ColorId = 5, ModelYear = 2013, DailyPrice = 10000, Description = "Fiat" },
            new Car { Id = 4, BrandId = 2, ColorId = 4, ModelYear = 2013, DailyPrice = 23500, Description = "BMW" },
            new Car { Id = 5, BrandId = 2, ColorId = 3, ModelYear = 1956, DailyPrice = 2000, Description = "Autobot" },
            new Car { Id = 6, BrandId = 1, ColorId = 2, ModelYear = 1993, DailyPrice = 540000, Description = "Decepticon" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(p => p.Id == car.Id).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }


        public void Update(Car car)
        {
            var updatedCar = _cars.SingleOrDefault(p => p.Id == car.Id);
            updatedCar.Id = car.Id;
            updatedCar.ColorId = car.ColorId;
            updatedCar.BrandId = car.BrandId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.Description = car.Description;
        }
    }
}
