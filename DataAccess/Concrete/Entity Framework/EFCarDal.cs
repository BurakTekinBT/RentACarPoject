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
    public class EFCarDal : ICarDal
    {
        
        public void Add(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedCar = context.Entry(entity);
                addedCar.State = EntityState.Added; 
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsBrandId(int i)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int i)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
