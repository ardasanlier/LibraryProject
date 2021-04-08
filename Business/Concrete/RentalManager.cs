using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilites.Business;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfRentalExists(rental));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalSucced);
        }

        public IDataResult<List<RentalDetail>> GetRentalDetails(User user, Book book)
        {
            return new SuccessDataResult<List<RentalDetail>>(_rentalDal.GetRentalDetails(user, book.BookId));
        }

        private IResult CheckIfRentalExists(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.BookId == rental.BookId).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentalExists);
            }
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);           
        }
    }
}
