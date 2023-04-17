using BookStore.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Service.AuthorSer;

namespace BookStore.Controllers
{
    public class AdminAuthorController : Controller
    {
        private IAuthorService _authorService;

        public AdminAuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult AuthorsList()
        {
            List<AuthorViewModel> model = new List<AuthorViewModel>();
            List<Author> authors = _authorService.GetAuthors();

            foreach (Author author in authors)
            {
                AuthorViewModel item = new AuthorViewModel
                {
                    Id = author.Id,
                    Name = author.Name,
                    CreatedDate = author.CreatedDate,
                    ModifiedDate = author.ModifiedDate
                };
                model.Add(item);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AuthorViewModel model = new AuthorViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Author author = new Author
                {
                    Name = model.Name,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _authorService.CreateAuthor(author);

                return RedirectToAction("AuthorsList", "AdminAuthor");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Author author = _authorService.GetAuthorById(Id);
            AuthorViewModel model = new AuthorViewModel
            {
                Id = Id,
                Name = author.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Author author = _authorService.GetAuthorById(model.Id);

                author.Name = model.Name;
                author.ModifiedDate = DateTime.Now;

                _authorService.UpdateAuthor(author);

                return RedirectToAction("AuthorsList", "AdminAuthor");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _authorService.DeleteAuthor(Id);
            return RedirectToAction("AuthorsList", "AdminAuthor");
        }
    }
}
