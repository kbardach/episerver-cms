using kim_episerver.Business.Services;
using kim_episerver.Models;
using kim_episerver.Models.Pages;
using kim_episerver.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace kim_episerver.Controllers
{
    public class SearchPageController : PageControllerBase<SearchPage>
    {
        private readonly IMovieService _movieService;

        public SearchPageController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index(SearchPage currentPage)
        {
            var model = new SearchPageViewModel(currentPage);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SearchMovie(SearchPage currentPage, string query)
        {
            var model = new SearchPageViewModel(currentPage)
            {
                Movies = await _movieService.GetMoviesWithDetailsAsync(query),
            };

            return View("~/views/searchpage/index.cshtml", model);
        }

        [HttpPost]
        public IActionResult RenderMoviePage(SearchPage currentPage, MovieDetails item)
        {
            var model = new MoviePageViewModel(currentPage);

            model.Movie = item;

            return View("~/views/searchpage/movie.cshtml", model);
        }
    }
}



/////////////////////////
///

//public class SearchPageController : PageControllerBase<SearchPage>
//{
//    private readonly IMovieService _movieService;

//    public SearchPageController(IMovieService movieService)
//    {
//        _movieService = movieService;
//    }

//    public IActionResult Index(SearchPage currentPage)
//    {
//        var model = new SearchPageViewModel(currentPage);
//        return View(model);
//    }

//    [HttpGet]
//    public async Task<IActionResult> SearchMovie(SearchPage currentPage, string query)
//    {
//        var model = new SearchPageViewModel(currentPage)
//        {
//            Movies = await _movieService.GetMoviesWithDetailsAsync(query),
//        };

//        return View("~/views/searchpage/index.cshtml", model);
//    }

//    public IActionResult RenderMoviePage(SearchPage currentPage, MovieDetails item)
//    {
//        var model = new MoviePageViewModel(currentPage);

//        model.Movie = item;

//        return View("~/views/searchpage/movie.cshtml", model);
//    }
//}