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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        [SecuredOperation("admin author")]
        [ValidationAspect(typeof(AuthorValidator))]
        [CacheRemoveAspect("IAuthorService.Get")]
        public IResult Add(Author author)
        {
            var result = BusinessRules.Run(CheckIfAuthorExists(author));
            if (!result.Success)
            {
                return result;
            }
            _authorDal.Add(author);
            return new SuccessResult(Messages.AuthorAdded);
        }

        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll());
        }

        private IResult CheckIfAuthorExists(Author author)
        {
            var result = _authorDal.GetAll(a => a.AuthorId == author.AuthorId).Any();
            if (result)
            {
                return new ErrorResult(Messages.AuthorExists);
            }
            return new SuccessResult();
        }
    }
}
