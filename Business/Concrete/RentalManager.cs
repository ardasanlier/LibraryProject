using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(RentalValidator))]
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

        public IDataResult<List<RentalDetail>> GetRentalDetails(User user)
        {
            return new SuccessDataResult<List<RentalDetail>>(_rentalDal.GetRentalDetails(user));
        }

        private IResult CheckIfRentalExists(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.BookId == rental.BookId && rental.ReturnDate>DateTime.Now).Any();
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
