using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,LibraryContext>,IRentalDal
    {
        public List<RentalDetail> GetRentalDetails(User user)
        {
            using (var context = new LibraryContext())
            {
                var result = from rentalDetail in context.RentalDetails
                             join rental in context.Rentals
                             on rentalDetail.RentalId equals rental.RentalId
                             where rental.UserId == user.Id
                             select new RentalDetail
                             {
                                 RentalId = rentalDetail.RentalId,
                                 Email = rentalDetail.Email,
                                 ReturnDate = rentalDetail.ReturnDate,
                                 TakeDate = rentalDetail.TakeDate,
                                 BookName = rentalDetail.BookName
                             };
                return result.ToList();

            }
        }
    }
}
