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
        return await movieRepository.GetById(id);
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
