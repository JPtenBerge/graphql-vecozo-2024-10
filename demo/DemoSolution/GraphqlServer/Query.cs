using GraphqlServer.Entities;
using GraphqlServer.Repositories;

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
