using GraphqlServer.Entities;
using GraphqlServer.Repositories;
using GraphqlServer.Types;

namespace GraphqlServer;

public class Mutation
{
    public Movie AddMovie(AddMovieInput input, IMovieRepository movieRepository)
    {
        var movie = movieRepository.Add(input.Title, input.ReleaseYear, input.DirectorId);
        return movie;
    }
}
