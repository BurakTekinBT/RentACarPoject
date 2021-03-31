using Business.Abstract;
using Business.CCS;
using Business.Constant;
using Business.ValidationRules.FluentValidations;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilites.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService; // bir cons sadece bir tane DAL Injectionı alır

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountCategoryCorrect(car.BrandId),
                (CheckIfCarNameExist(car.Description)) , CheckIfBrandLimitExceded());

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Araç Silindi");
        }

        [ValidationAspect(typeof(CarValidator))]
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

        private IResult CheckIfCarCountCategoryCorrect(int brandId)
        {
            var result = _carDal.GetAll(p => p.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _carDal.GetAll(p => p.Description == carName).Any();

            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExist);
            }

            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();

            if (result.Data.Count> 15)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }

            return new SuccessResult();
        }

    }
}
