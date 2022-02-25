using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            var car = new Car { BrandId=5,ColorId=2,DailyPrice=510,Description="Full Paket",ModelYear=2021,Name="E200"};
            carManager.Add(car);
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Name + cars.DailyPrice);
            }
        }
    }
}
