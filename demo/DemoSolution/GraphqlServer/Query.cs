using GraphqlServer.Entities;
using GraphqlServer.Repositories;
using GraphqlServer.Types;

namespace GraphqlServer;

public class Query
{
    public string HelloWorld()
    {
        return "whoa! Hello world";
    }

    public async Task<IEnumerable<Movie>?> Movies(IMovieRepository movieRepository)
    {
        return await movieRepository.GetAll();
    }

    public async Task<Movie?> GetMovieById(int id, IMovieRepository movieRepository)
    {
        Console.WriteLine("[query] GetMovieById " + id);
        return await movieRepository.GetById(id);
    }

    public IEnumerable<Movie> GetMoviesByGenre(Genre genre, IMovieRepository movieRepository)
    {
        return movieRepository.GetByGenre(genre);
    }

    public async Task<IEnumerable<IWatchable>> GetWatchables(IMovieRepository movieRepository, ShowRepository showRepository)
    {
        var movies = await movieRepository.GetAll();
        var shows = showRepository.GetAll();

        var watchables = new List<IWatchable>();
        watchables.AddRange(movies);
        watchables.AddRange(shows);
        return watchables;
    }

    public async Task<IEnumerable<IOffering>> GetOffering(IMovieRepository movieRepository)
    {
        var offerings = new List<IOffering>();
        var movies = await movieRepository.GetAll();
        offerings.AddRange(movies);
        offerings[1] = new MovieError { Reason = "Niet voor jouw land" };
        return offerings;
    }

    public string FilterMovie(FilterMovieInput input)
    {

        return $"filteren met: {input.DirectorName} / {input.ReleaseYear}";
    }

    public Movie? BestMovie()
    {
        //return null;
        return new()
        {
            Title = "Titanic",
            ReleaseYear = 1997,
            DirectorId = 4
        };
    }
}
