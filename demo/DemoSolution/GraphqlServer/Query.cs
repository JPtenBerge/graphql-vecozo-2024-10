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

    public async Task<IEnumerable<Movie>?> Movies([Service] MovieRepository movieRepository)
    {
        return await movieRepository.GetAll();
    }

    public async Task<Movie?> GetMovieById(int id, [Service] MovieRepository movieRepository)
    {
        return await movieRepository.GetById(id);
    }

    public string FilterMovie(FilterMovieInputType input)
    {
        return $"filteren met: {input.DirectorName} / {input.ReleaseYear}";
    }

    public Movie? BestMovie()
    {
        //return null;
        return new()
        {
            Title = "Titanic",
            ReleaseYear = 1997
        };
    }
}
