using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length>=2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç ekleme işlemi başarılı ");
            }
            else
            {
                Console.WriteLine("Hatalı araç girişi");
            }
        }

        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
           return _carDal.GetAll();
        }

        public List<Car> GetById(int i)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsBrandId(int i)
        {
            return _carDal.GetAll(p => p.BrandId == i);
        }

        public List<Car> GetCarsByColorId(int i)
        {
            return _carDal.GetAll(p => p.ColorId == i);
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
