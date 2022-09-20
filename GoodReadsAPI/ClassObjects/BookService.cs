using BusinessLogic;
using DatabaseService.Models;
using GoodReadsAPI.Data;
using GoodReadsAPI.Interfaces;

namespace GoodReadsAPI.ClassObjects
{
    public class BookService : IBookService
    {
        private ApiContext _book;
        public BookService(ApiContext book)
        {
            _book = book;
        }
        public Book Save(Book book)
        {
            var validator = new Validator();
            if (validator.isValid(book)==false)
            {
                book.Error = validator.ErrorMessage;
                return book;
            }

            var bookInDb = _book.Books.Find(book.Id);


            if (bookInDb == null)
            {
                _book.Books.Add(book);
                _book.SaveChanges();
            }
            else
            {
                book.Error = "Unavailable Id";
            }

            return book;
        }
    }
}
