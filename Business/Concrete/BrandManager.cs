using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new Result(true, "MArka eklendi");
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, "MArka Silindi");
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, "MArka Güncellendi");
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(), true, "Listeleme başarılı");
        }
        public IDataResult<Brand> GetById(int brandId)
        {
            return new DataResult<Brand>(_brandDal.GetById(b => b.Id == brandId), true, "Başarılı getirildi");
        }

    }
}
