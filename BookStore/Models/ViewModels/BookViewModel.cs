using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        public int AuthorId { get; set; }
        public SelectList? Authors { get; set; }
        public int GenreId { get; set; }
        public SelectList? Genres { get; set; }
    }
}
