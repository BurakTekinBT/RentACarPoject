using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car { Id = 6, BrandId = 1, ColorId = 2, ModelYear = 1993, DailyPrice = 540000, Description = "Deceddpticon" });

            

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("Tüm araçlar \n Araç Markası : {0}\n Araç Yılı : {1}\n Araç Fiyatı : {2}\n ", item.Description, item.ModelYear, item.DailyPrice);
            }
        }
    }
}
