using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentalDbContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join r in context.Colors on c.ColorId equals r.Id
                             select new CarDetailDTO 
                             { CarName = c.Name, ColorName = r.Name, 
                                 BrandName = b.Name, DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                return context.Set<Car>().Where(c => c.BrandId == BrandId).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                return context.Set<Car>().Where(c => c.ColorId == ColorId).ToList();
            }
        }
    }
}
