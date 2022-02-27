using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Message.Added);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Message.Listened);
        }

        public IDataResult<Brand> GetByID(int Id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.Id == Id), Message.Listened);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Message.Updated);
        }
    }
}
