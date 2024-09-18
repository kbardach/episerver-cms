using kim_episerver.Models.Pages;
using kim_episerver.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace kim_episerver.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public IActionResult Index(StartPage currentPage)
        {
            var model = new StartPageViewModel(currentPage);

            return View(model);
        }
    }
}
