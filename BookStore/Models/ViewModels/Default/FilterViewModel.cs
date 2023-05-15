using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models.ViewModels.Default
{
    public class FilterViewModel
    {
        public SelectList Genres { get; }
        public int SelectedGenre { get; }
        public string SelectedSearch { get; }

        public FilterViewModel(List<GenreViewModel> genres, int genreId, string search)
        {
            genres.Insert(0, new GenreViewModel { Name = "Все", Id = 0 });
            Genres = new SelectList(genres, "Id", "Name", genreId);
            SelectedGenre = genreId;
            SelectedSearch = search;
        }
    }
}
