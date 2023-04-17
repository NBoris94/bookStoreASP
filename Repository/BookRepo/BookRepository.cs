using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BookRepo
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;

        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book Get(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = Get(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
