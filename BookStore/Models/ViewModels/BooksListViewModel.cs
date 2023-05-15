using BookStore.Models.ViewModels.Default;

namespace BookStore.Models.ViewModels
{
    public class BooksListViewModel
    {
        public List<BookViewModel> Books { get; }
        public PageViewModel PageViewModel { get; }
        public SortViewModel SortViewModel { get; }
        //public FilterViewModel FilterViewModel { get; }

        public BooksListViewModel
        (
            List<BookViewModel> books,
            PageViewModel pageViewModel,
            SortViewModel sortViewModel
            //FilterViewModel filterViewModel
        )
        {
            Books = books;
            PageViewModel = pageViewModel;
            SortViewModel = sortViewModel;
            //FilterViewModel = filterViewModel;
        }
    }
}
