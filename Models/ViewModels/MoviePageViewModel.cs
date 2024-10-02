using kim_episerver.Models;
using kim_episerver.Models.Pages;
using kim_episerver.Models.ViewModels;

namespace kim_episerver.Models.ViewModels
{
    public class MoviePageViewModel : PageViewModel<SearchPage>
    {
        public MoviePageViewModel(SearchPage currentPage) : base(currentPage)
        {
        }

        public MovieDetails Movie { get; set; }
    }
}
