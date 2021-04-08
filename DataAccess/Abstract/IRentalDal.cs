using Core.DataAccess;
using Core.Entities.Concrete;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentalDetail> GetRentalDetails(User user, int bookId);
    }
}
