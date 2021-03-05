using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int productId);
        IDataResult<List<Car>> GetCarsBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);

    }
}
