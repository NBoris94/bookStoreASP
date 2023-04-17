using BookStore.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Service.GenreSer;

namespace BookStore.Controllers
{
    public class AdminGenreController : Controller
    {
        private IGenreService _genreService;

        public AdminGenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult GenresList()
        {
            List<GenreViewModel> model = new List<GenreViewModel>();
            List<Genre> genres = _genreService.GetGenres();

            foreach(Genre genre in genres)
            {
                GenreViewModel item = new GenreViewModel { 
                    Id = genre.Id,
                    Name = genre.Name,
                    CreatedDate = genre.CreatedDate,
                    ModifiedDate = genre.ModifiedDate
                };
                model.Add(item);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GenreViewModel model = new GenreViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                Genre genre = new Genre
                {
                    Name = model.Name,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _genreService.CreateGenre(genre);

                return RedirectToAction("GenresList", "AdminGenre");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Genre genre = _genreService.GetGenreById(Id);
            GenreViewModel model = new GenreViewModel
            {
                Id = Id,
                Name = genre.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(GenreViewModel model)
        {
            if (ModelState.IsValid)
            {
                Genre genre = _genreService.GetGenreById(model.Id);

                genre.Name = model.Name;
                genre.ModifiedDate = DateTime.Now;

                _genreService.UpdateGenre(genre);

                return RedirectToAction("GenresList", "AdminGenre");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _genreService.DeleteGenre(Id);
            return RedirectToAction("GenresList", "AdminGenre");
        }
    }
}
