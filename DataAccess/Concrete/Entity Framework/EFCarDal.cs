using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {

        //public void Add(Car entity)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var addedCar = context.Entry(entity);
        //        addedCar.State = EntityState.Added; 
        //        context.SaveChanges();
        //    }
        //}

        //public void Delete(Car entity)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        var deletedCar = context.Entry(entity);
        //        deletedCar.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (RentACarContext context = new RentACarContext())
        //    {
        //        return filter == null ? context.Set<Car>().ToList()
        //            : context.Set<Car>().Where(filter).ToList();
        //    }
        //}
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.ColorId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList();
            }
            
        }
    }
}
