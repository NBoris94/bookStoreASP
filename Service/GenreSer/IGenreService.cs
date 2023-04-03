using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.GenreSer
{
    public interface IGenreService
    {
        List<Genre> GetGenres();
        Genre GetGenreById(int id);
        void CreateGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(int id);
    }
}
