using BookStore.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Service.BookSer;

namespace BookStore.Controllers
{
    public class AdminBookController : Controller
    {
        private IBookService _bookService;

        public AdminBookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            List<BookViewModel> model = new List<BookViewModel>();
            List<Book> books = _bookService.GetBooks();

            if (books != null)
            {
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
            }

            return View(model);
        }
    }
}
