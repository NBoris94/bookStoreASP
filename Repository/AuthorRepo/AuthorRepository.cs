using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AuthorRepo
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author Get(int id)
        {
            return _context.Authors.FirstOrDefault(b => b.Id == id);
        }

        public void Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Author author = Get(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
