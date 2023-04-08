using Data;
using Repository.BookRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.BookSer
{
    public class BookService : IBookService
    {
        private IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetBooks()
        {
            return _repository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _repository.Get(id);
        }

        public void CreateBook(Book book)
        {
            _repository.Create(book);
        }

        public void UpdateBook(Book book)
        {
            _repository.Update(book);
        }

        public void DeleteBook(int id)
        {
            _repository.Delete(id);
        }
    }
}
