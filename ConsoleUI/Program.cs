using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "AUDI" });
            var brands = brandManager.GetAll();
            foreach (var item in brands)
            {
                Console.WriteLine("MARKA :{0} ",item.BrandName);
            }

            //ColorManager colorManager = new Business.Concrete.ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorName = "BEYAZ" });
            //var colors = colorManager.GetAll();
            //foreach (var item in colors)
            //{
            //    Console.WriteLine("RENK :{0} ", item.ColorName);
            //}

            CarManager carManager = new Business.Concrete.CarManager(new EfCarDal());
            carManager.Add(new Car{ ColorId = 1, BrandId = 2, ModelYear = 2021, DailyPrice = 300, Description = "Otomatik sarj" });
            var carDetails = carManager.GetCarDetails();
            foreach (var item in carDetails)
            {
                Console.WriteLine("Model :{0} Araç Rengi :{ 1}  Günlük Fiyatı :{ 2}  ",item.BrandName, item.ColorName, item.DailyPrice, item.ColorName);
            }
        }
    }
}
