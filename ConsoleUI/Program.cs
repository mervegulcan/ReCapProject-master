using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            CarDetails();
            // RentalDetailsDetails();

            //BrandManager bman = new BrandManager(new EfBrandDal());
            //var result = bman.GetAll();
            //foreach (var item in result.Data)
            //{
            //    Console.WriteLine(item.Name);
            //}


        }
        private static void RentalDetailsDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            foreach (var ren in rentalManager.GetRentalDetailsDto(1).Data)
            {

                Console.WriteLine(ren.CarName + " rentdate : " + string.Format("{0:dd.MM.yyyy}", ren.RentDate));
            }
        }

            private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            var carDetails = carManager.GetCarDetails();
            if (carDetails.Success == true)
            {
                foreach (var car in carDetails.Data)
                {
                    Console.WriteLine(car.Id + "/"+ car.Name + "/ Marka :" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine("Hata :"+carDetails.Message);
            }
        }

        
    }
}
