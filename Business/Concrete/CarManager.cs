using Business.Abstract;
using Core.Results;
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
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new Result(true, "Selam");
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Araç Silindi");
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, "Araç Güncellendi");
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(), true, "Listeleme başarılı");
        }
        public IDataResult<Car> GetById(int carId)
        {
            return new DataResult<Car>(_carDal.GetById(c => c.Id == carId), true, "Başarılı getirildi");
        }

        public IDataResult<List<Car>> GetCarsBrandId(int brandId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId), true, "Başarılı listeleme");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int i)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == i), true, "   Başarılı çağırma");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), true, "Başarılı Listemleme");
        }
    }
}
