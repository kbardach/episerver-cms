using EPiServer.Web.Mvc;
using kim_episerver.Controllers;
using kim_episerver.Models.Pages;
using kim_episerver.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace kim_episerver.Controllers
{
    public class ErrorPageController : PageController<ErrorPage>
    {
        public IActionResult Index(ErrorPage currentPage)
        {
            var model = new ErrorPageViewModel(currentPage);

            return View(model);
        }
    }
}



//ErrorPageController ärver från PageController<ErrorPage>, vilket betyder att den är en specifik controller
//för att hantera sidor av typen ErrorPage. PageController är en generisk klass som hanterar vanliga
//sidkontroller i ett CMS (t.ex. Episerver/Optimizely). Genom att ange <ErrorPage> specificeras
//att denna controller är kopplad till en sida av typen ErrorPage.
//ErrorPage är modellen för en fel-sida, som hanterar innehållet eller layouten för en viss typ av
//felmeddelande. public class ErrorPageController : PageController<ErrorPage>
//{
//    // Index-metoden är en action som körs när användaren besöker en ErrorPage
//    // Den returnerar ett IActionResult som representerar resultatet av en HTTP-begäran
//    public IActionResult Index(ErrorPage currentPage)
//    {
//        // Skapar en instans av ErrorPageViewModel och skickar den aktuella ErrorPage-sidan (currentPage) som parameter
//        var model = new ErrorPageViewModel(currentPage);

//        // Returnerar en vy (View) med den skapade modellen
//        return View(model);
//    }
//}
