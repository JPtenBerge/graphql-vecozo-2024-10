using GraphqlServer.Entities;

namespace GraphqlServer.Repositories;

public class MovieRepository
{
    private static List<Movie> s_movies = new()
    {
        new()
        {
            Title = "Titanic",
            ReleaseYear = 1997
        },
        new()
        {
            Title = "Kung-fu Panda 4: This time it's personal",
            ReleaseYear = 2025
        },
        new()
        {
            Title = "Oppenheimer",
            ReleaseYear = 2023
        }
    };

    public async Task<IEnumerable<Movie>> GetAll()
    {
        await Task.Delay(2000);
        return null;
    }
}
