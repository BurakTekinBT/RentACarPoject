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
            //CarManager();

            BrandManager colorManager = new BrandManager(new EFBrandDal());

            //colorManager.Delete(new Brand() { brandName ="Decepticon" , Id=3  });

            var item = colorManager.GetAll();

            foreach (var i in item.Data)
            {
                Console.WriteLine(i.brandName);
            }

        }

        private static void CarManager()
        {
            CarManager carManager = new CarManager(new EFCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {

                foreach (var vehicle in result.Data)
                {
                    Console.WriteLine(vehicle.Description + " " + vehicle.BrandName + " " + vehicle.colorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}
