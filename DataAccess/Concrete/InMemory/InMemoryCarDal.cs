using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars= new List<Car> { 
            new Car {Id=1,Name="Mondeo",BrandId=1,ColorId=7,ModelYear=2022,DailyPrice=412,Description="Ford Mondeo" },
            new Car {Id=2,Name="Focus",BrandId=1,ColorId=3,ModelYear=2020,DailyPrice=234,Description="Ford Focus" },
            new Car {Id=3,Name="Fiesta",BrandId=1,ColorId=4,ModelYear=2021,DailyPrice=212,Description="Ford Fiesta" },
            new Car {Id=4,Name="Leon",BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=321,Description="Seat Leon" },
            new Car {Id=5,Name="Rio",BrandId=3,ColorId=6,ModelYear=2019,DailyPrice=311,Description="Kia Rio" },
            new Car {Id=6,Name="i20",BrandId=4,ColorId=1,ModelYear=2022,DailyPrice=251,Description="Hyundai i20" },
            new Car {Id=7,Name="5.20",BrandId=5,ColorId=2,ModelYear=2020,DailyPrice=540,Description="BMW 520" }};
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete =_cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetByID(int ID)
        {
            return _cars.SingleOrDefault(c=>c.Id== ID);
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;  
            carToUpdate.DailyPrice = car.DailyPrice; 
            carToUpdate.Description = car.Description;
        }
    }
}
