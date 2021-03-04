using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());

            carManager.Add( new Car { BrandId=2, ColorId=1, DailyPrice=1, ModelYear=1999, Description="Mercedes"});

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

            foreach (var item in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(item.Description);
            }
            foreach (var item in carManager.GetCarsBrandId(1))
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
