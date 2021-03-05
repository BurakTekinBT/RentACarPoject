using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new Result(true, "Renk eklendi");
        }
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, "Renk Silindi");
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, "Renk Güncellendi");
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(), true, "Listeleme başarılı");
        }
        public IDataResult<Color> GetById(int colorId)
        {
            return new DataResult<Color>(_colorDal.GetById(c => c.Id == colorId), true, "Başarılı getirildi");
        }
    }
}
