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
            CarManager();

        }

        private static void CarManager()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());

            //foreach (var clr in colorManager.GetAll())
            //{
            //    Console.WriteLine(clr.colorName);
            //}
            //Console.WriteLine("Silme İşlemi Sonrası : ");

            //var del = carManager.GetById(4);
            //carManager.Delete( del);
            //brandManager.Add(new Brand { brandName = " Decepticon" });

            //foreach (var bm in brandManager.GetAll())
            //{
            //    Console.WriteLine(bm.brandName);
            //}

            //colorManager.Add(new Color { Id=4,colorName = "Purple" });


            //foreach (var clr in colorManager.GetAll())
            //{
            //    Console.WriteLine(clr.colorName);
            //}

            //colorManager.Add(new Color { colorName = "Mor" });
            carManager.Add(new Car { BrandId =2 , ColorId =2 , DailyPrice = 155555, ModelYear = 2019, Description = "Autobot" });

            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Description);
            //}
            //Console.WriteLine("Silme İşlemi Sonrası : " );

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.Description + " " + item.BrandName);
            }

            //foreach (var item in carManager.GetCarsByColorId(3))
            //{
            //    Console.WriteLine(item.Description);
            //}
            //foreach (var item in carManager.GetCarsBrandId(1))
            //{
            //    Console.WriteLine(item.Description);
            //}
        }
    }
}
