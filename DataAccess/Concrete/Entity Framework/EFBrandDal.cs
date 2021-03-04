using Core.Data_Access.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFBrandDal : EfEntityRepositoryBase<Brand, RentACarContext>, IBrandDal
    {

    }
}
