using kim_episerver.Models.Pages;

namespace kim_episerver.Models.ViewModels
{
    public class SearchPageViewModel : PageViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage currentPage) : base(currentPage)
        {
        }

        public List<MovieDetails> Movies { get; set; }
    }
}
