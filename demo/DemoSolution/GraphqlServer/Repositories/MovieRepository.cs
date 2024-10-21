using GraphqlServer.Entities;

namespace GraphqlServer.Repositories;

public class MovieRepository
{
    private static List<Movie> s_movies = new()
    {
        new()
        {
            Title = "Titanic",
            ReleaseYear = 1997,
            DirectorId = 4
        },
        new()
        {
            Title = "Kung-fu Panda 4: This time it's personal",
            ReleaseYear = 2025,
            DirectorId = 8
        },
        new()
        {
            Title = "Oppenheimer",
            ReleaseYear = 2023,
            DirectorId = 15
        }
    };

    public async Task<IEnumerable<Movie>> GetAll()
    {
        await Task.Delay(2000);
        return s_movies;
    }
}
