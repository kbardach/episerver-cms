using EPiServer.DataAccess;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.Security;
using EPiServer.Web;
using kim_episerver.Models.Pages;

namespace kim_episerver.Business.ScheduledJobs
{

    [ScheduledPlugIn(
    DisplayName = "Handle Movie Pages",
    Description = "This job delete movie pages",
    GUID = "1F4628A0-36AD-48B4-B4E1-AB5083A1B00B"
)]
    public class HandleMoviePages : ScheduledJobBase
    {
        // Fält för att injicera nödvändiga beroenden: IContentLoader för att ladda innehåll,
        // ISiteDefinitionRepository för att hämta webbplatsdefinitioner,
        // IContentRepository för att hantera och spara innehåll i Episerver.
        private readonly IContentLoader _contentLoader;
        private readonly ISiteDefinitionRepository _siteDefinitionRepository;
        private readonly IContentRepository _contentRepository;
        private bool _stopSignaled;  // Används för att signalera när jobbet ska stoppas.

        // Konstruktorn injicerar nödvändiga beroenden i klassen.
        public HandleMoviePages(IContentLoader contentLoader, ISiteDefinitionRepository siteDefinitionRepository, IContentRepository contentRepository)
        {
            _contentLoader = contentLoader;
            _siteDefinitionRepository = siteDefinitionRepository;
            _contentRepository = contentRepository;
            IsStoppable = true;  // Gör jobbet stoppbart om det behövs.
        }

        // Metoden som används för att stoppa jobbet genom att sätta _stopSignaled till true.
        public override void Stop()
        {
            _stopSignaled = true;
        }

        // Denna metod körs när jobbet exekveras. Här skapas och raderas filmsidor.
        public override string Execute()
        {
            // Skapar en filmsida (kan kommenteras bort om man bara vill radera).
            CreateMoviePages();


            //Använd denn och man ser att filmen skapas(Kommentera ut det under, så jobbet inte raderas)
            //return $"1 movie page created";


            // Denna del raderar alla filmsidor som hittas.
            var movies = GetMoviePages();
            var status = 0;

            // Gå igenom alla sidor som hittats och radera dem.
            foreach (var item in movies)
            {
                _contentRepository.Delete(item.ContentLink, true, AccessLevel.NoAccess);
                status++;
            }

            // Om jobbet stoppas innan det slutförs returneras ett meddelande om att det avbröts.
            if (_stopSignaled)
            {
                return "The job has been cancelled";
            }

            // Returnerar hur många sidor som raderades.
            return $"Movie pages deleted: {status}";
        }

        // Denna metod hämtar alla sidor av typen SavedMoviePage som är sparade i en specifik container (länkad via inställningar).
        private List<SavedMoviePage> GetMoviePages()
        {
            var movies = new List<SavedMoviePage>();
            var startPage = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var settingsPage = _contentLoader.GetChildren<SettingsPage>(startPage).FirstOrDefault();

            // Kontrollera om LinkToMoviesContainer är inställt och hämta filmer från containern.
            if (settingsPage.LinkToMoviesContainer != null)
            {
                var moviesContainer = _contentLoader.Get<ContainerPage>(settingsPage.LinkToMoviesContainer);
                movies = _contentLoader.GetChildren<SavedMoviePage>(moviesContainer.ContentLink).ToList();
            }

            return movies;  // Returnerar en lista med alla hämtade SavedMoviePages.
        }


        // todo - Bryt ut i en service (Denna används bara för att man ska kunna se att ett jobb raderar i schemalagdaJob)
        // Denna metod skapar en ny sida av typen SavedMoviePage och sparar den i containern.
        private void CreateMoviePages()
        {
            var contentReference = _siteDefinitionRepository.List().FirstOrDefault().StartPage;
            var settingsPage = _contentLoader.GetChildren<SettingsPage>(contentReference).FirstOrDefault();

            // Kontrollera om LinkToMoviesContainer är satt och skapa sidan där.
            if (settingsPage.LinkToMoviesContainer != null)
            {
                var moviesContainer = _contentLoader.Get<ContainerPage>(settingsPage.LinkToMoviesContainer);
                var savedMoviePage = _contentRepository.GetDefault<SavedMoviePage>(moviesContainer.ContentLink);

                // Sätt egenskaper för filmsidan (namn och rubrik).
                savedMoviePage.Name = "Inception";
                savedMoviePage.Heading = "Nice movie";

                // Spara och publicera den nya filmsidan.
                _contentRepository.Save(savedMoviePage, SaveAction.Publish, AccessLevel.NoAccess);
            }
        }
    }

}
