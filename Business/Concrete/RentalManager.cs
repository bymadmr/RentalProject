using Business.Abstract;
using Business.Constants;
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
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var controlData = _rentalDal.GetAll(c => c.CarId == rental.CarId).OrderByDescending(x=>x.Id).ToList().FirstOrDefault();
            if (controlData ==null || controlData.ReturnDate!=null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Message.Added);
            }
            return new ErrorResult(Message.CarNotAvailable);
            
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Message.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Message.Listened);
        }

        public IDataResult<Rental> GetByID(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == Id), Message.Listened);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Message.Updated);
        }
    }
}
