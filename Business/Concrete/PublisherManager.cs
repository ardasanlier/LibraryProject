using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilites.Business;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PublisherManager : IPublisherService
    {
        IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        [SecuredOperation("admin,publisher")]
        [CacheRemoveAspect("IPublisherService.Get")]
        [ValidationAspect(typeof(PublisherValidator))]
        public IResult Add(Publisher publisher)
        {
            IResult result = BusinessRules.Run(CheckIfPublisherExists(publisher));
            if (result != null)
            {
                return result;
            }
            _publisherDal.Add(publisher);
            return new SuccessResult(Messages.PublisherAdded);
        }

        public IDataResult<List<Publisher>> GetAll()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll());
        }

        [SecuredOperation("admin,publisher")]
        [CacheRemoveAspect("IPublisherService.Get")]
        [ValidationAspect(typeof(PublisherValidator))]
        public IResult Update(Publisher publisher)
        {
            _publisherDal.Update(publisher);
            return new SuccessResult(Messages.PublisherUpdated);
        }

        private IResult CheckIfPublisherExists(Publisher publisher)
        {
            var result = _publisherDal.GetAll(b => b.PublisherId == publisher.PublisherId).Any();
            if (result)
            {
                return new ErrorResult(Messages.PublisherExists);
            }
            return new SuccessResult();
        }
    }
}
