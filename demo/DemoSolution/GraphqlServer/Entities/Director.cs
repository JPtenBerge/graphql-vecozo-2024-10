using GraphqlServer.Repositories;

namespace GraphqlServer.Entities;

public class Director
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public async Task<Movie?> BestMovie([Service] MovieRepository movieRepo)
    {
        return await movieRepo.GetById(18);
    }
}
