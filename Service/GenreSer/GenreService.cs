using Data;
using Repository.GenreRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.GenreSer
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }

        public List<Genre> GetGenres()
        {
            return _repository.GetAll();
        }

        public Genre GetGenreById(int id)
        {
            return _repository.Get(id);
        }

        public void CreateGenre(Genre genre)
        {
            _repository.Create(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            _repository.Update(genre);
        }

        public void DeleteGenre(int id)
        {
            _repository.Delete(id);
        }
    }
}
