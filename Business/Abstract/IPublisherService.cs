using Core.Utilites.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        IResult Add(Publisher publisher);
        IResult Update(Publisher publisher);
        IDataResult<List<Publisher>> GetAll();
    }
}
