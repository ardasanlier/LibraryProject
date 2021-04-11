using Core.Entities.Concrete;
using Core.Utilites.Results;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetRentalByUserId(int userId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        
    }
}
