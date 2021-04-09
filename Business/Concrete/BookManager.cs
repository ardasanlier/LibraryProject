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
    public class BookManager : IBookService
    {
        IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        [SecuredOperation("book.add admin")]
        [CacheRemoveAspect("IBookService.Get")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            IResult result = BusinessRules.Run(CheckIfBookExists(book));
            if (!result.Success)
            {
                return result;
            }
            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        [SecuredOperation("book.delete admin")]
        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }

        [CacheAspect(60)]
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll().ToList());
        }

        public IDataResult<List<Book>> GetByAuthor(int authorId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(p => p.AuthorId == authorId));
        }

        public IDataResult<List<Book>> GetByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.CategoryId == categoryId));
        }

        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(p => p.BookId == bookId));
        }

        public IDataResult<List<Book>> GetByPublisher(int publisherId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.PublisherId == publisherId));
        }

        [SecuredOperation("book.update admin")]
        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(Messages.BookUpdated);
        }

        private IResult CheckIfBookExists(Book book)
        {
            var result = _bookDal.GetAll(b => b.BookId == book.BookId).Any();
            if (result)
            {
                return new ErrorResult(Messages.BookExists);
            }
            return new SuccessResult();
        }
    }
}
