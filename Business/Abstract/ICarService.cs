using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);

        List<CarDetailDto> GetCarDetails();
        List<Car> GetAll();

        Car GetById(int i);

        List<Car> GetCarsBrandId(int i);

        List<Car> GetCarsByColorId(int i);

    }
}
