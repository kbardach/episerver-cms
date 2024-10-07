using EPiServer.Shell.Search;
using kim_episerver.Business.Services.Interfaces;
using kim_episerver.Models;
using Newtonsoft.Json;

namespace kim_episerver.Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MovieService> _logger;
        private readonly string? _apiKey;

        public MovieService(HttpClient httpClient, ILogger<MovieService> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiKey = configuration["MovieApiKey"];
        }

        public async Task<List<MovieDetails>> GetMoviesWithDetailsAsync(string query)
        {
            var movies = new List<MovieDetails>();

            try
            {
                var firstRequest = new HttpRequestMessage(HttpMethod.Get, $"https://www.omdbapi.com/?s={query}&apikey={_apiKey}");
                var firstResponse = await _httpClient.SendAsync( firstRequest );

                if (firstResponse.IsSuccessStatusCode)
                {
                    var firstJson = await firstResponse.Content.ReadAsStringAsync();
                    var searchResult = JsonConvert.DeserializeObject<Root>(firstJson);

                    if (searchResult?.Search != null)
                    {
                        foreach (var movie in searchResult.Search)
                        {
                            var secondRequest = new HttpRequestMessage(HttpMethod.Get, $"https://www.omdbapi.com/?i={movie.ImdbID}&apikey={_apiKey}");
                            var secondResponse = await _httpClient.SendAsync( secondRequest );

                            if (secondResponse.IsSuccessStatusCode)
                            {
                                var secondJson = await secondResponse.Content.ReadAsStringAsync();
                                var movieDetails = JsonConvert.DeserializeObject<MovieDetails>(secondJson);

                                if (movieDetails != null)
                                {
                                    movies.Add(movieDetails);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
            }

            return movies;
        }
    }
}
