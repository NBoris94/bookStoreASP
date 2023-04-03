using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenreRepo
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationContext _context;

        public GenreRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public Genre Get(int id)
        {
            return _context.Genres.FirstOrDefault(i => i.Id == id);
        }

        public void Create(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Genre genre = Get(id);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
