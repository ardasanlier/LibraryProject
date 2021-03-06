using Core.Utilites.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<Book>> GetByCategoryId(int categoryId);
        IDataResult<Book> GetById(int bookId);
        IDataResult<List<Book>> GetByPublisher(int publisherId);
        IDataResult<List<Book>> GetByAuthor(int authorId);
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
    }
}
