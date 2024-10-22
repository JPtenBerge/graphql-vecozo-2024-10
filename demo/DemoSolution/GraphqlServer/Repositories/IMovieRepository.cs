using GraphqlServer.Entities;
using GraphqlServer.Types;

namespace GraphqlServer.Repositories
{
    public interface IMovieRepository
    {
        Movie Add(string title, int releaseYear, int directorId);
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie?> GetById(int id);
        IEnumerable<Movie> GetByGenre(Genre genre);
    }
}