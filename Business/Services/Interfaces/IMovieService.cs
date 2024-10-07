using kim_episerver.Models;

namespace kim_episerver.Business.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDetails>> GetMoviesWithDetailsAsync(string query);
    }
}