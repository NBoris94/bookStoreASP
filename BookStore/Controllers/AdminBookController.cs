using BookStore.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.AuthorSer;
using Service.BookSer;

namespace BookStore.Controllers
{
    public class AdminBookController : Controller
    {
        private IAuthorService _authorService;
        private IBookService _bookService;

        public AdminBookController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public IActionResult BooksList()
        {
            List<BookViewModel> model = new List<BookViewModel>();
            List<Book> books = _bookService.GetBooks();
        

            foreach (Book book in books)
            {
                BookViewModel bvm = new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    CreatedDate = book.CreatedDate,
                    ModifiedDate = book.ModifiedDate
                };
        
                model.Add(bvm);
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Create()
        {
            List<Author> authors = _authorService.GetAuthors();
            BookViewModel model = new BookViewModel();
            List<AuthorViewModel> authorsList = new List<AuthorViewModel>();

            foreach (Author author in authors)
            {
                AuthorViewModel authorViewModel = new AuthorViewModel
                {
                    Id = author.Id,
                    Name = author.Name
                };

                authorsList.Add(authorViewModel);
            }

            model.Authors = new SelectList(authorsList, "Id", "Name");

            return View(model);
        }


        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book
                {
                    Price = model.Price,
                    Title = model.Title,
                    Description = model.Description,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                _bookService.CreateBook(book);

                return RedirectToAction("BooksList", "AdminBook");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            Book book = _bookService.GetBookById(Id);
            BookViewModel model = new BookViewModel
            {
                Id = Id,
                Title = book.Title
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                Book book = _bookService.GetBookById(model.Id);

                book.Title = model.Title;
                book.ModifiedDate = DateTime.Now;

                _bookService.UpdateBook(book);

                return RedirectToAction("BooksList", "AdminBook");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            _bookService.DeleteBook(Id);
            return RedirectToAction("BooksList", "AdminBook");
        }

    }

}
