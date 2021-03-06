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

            UserManager userManager = new UserManager(new EfUserDal());

            //colorManager.Delete(new Brand() { brandName ="Decepticon" , Id=3  });


            userManager.Add(new User { FirstName = "ilyas", LastName = " Tekin", Email = " ilyas@gmail.com", Password = 12345 });

                foreach (var us in userManager.GetAll().Data)
                {
                    Console.WriteLine(us.FirstName);
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
                    Console.WriteLine(vehicle.Description + " " + vehicle.BrandName + " " + vehicle.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }
    }
}
