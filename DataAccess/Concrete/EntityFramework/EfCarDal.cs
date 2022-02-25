using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (RentalDbContext context= new RentalDbContext())
            {
                var addedEntity = context.Entry(car);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                var deletedEntity = context.Entry(car);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car,bool>> filter=null)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            } 
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                return context.Set<Car>().Where(c=>c.BrandId== BrandId).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                return context.Set<Car>().Where(c => c.ColorId == ColorId).ToList();
            }
        }

        public void Update(Car car)
        {
            using (RentalDbContext context = new RentalDbContext())
            {
                var updatedEntity = context.Entry(car);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
