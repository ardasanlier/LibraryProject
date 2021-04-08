using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExists(book));
            if (result != null)
            {
                return result;
            }
            _bookDal.Add(book);
            return new SuccessResult(Messages.BookAdded);
        }

        public IResult Delete(Book book)
        {
            _bookDal.Delete(book);
            return new SuccessResult(Messages.BookDeleted);
        }

        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll().ToList());
        }

        public IDataResult<List<Book>> GetByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.CategoryId == categoryId).ToList());
        }

        public IDataResult<Book> GetById(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(p => p.BookId == bookId));
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(Messages.BookUpdated);
        }

        private IResult CheckIfBookNameExists(Book book)
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
