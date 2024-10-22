using GraphqlServer.Repositories;
using GraphqlServer.Types;

namespace GraphqlServer.Entities;

public class Movie
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int ReleaseYear { get; set; }

    public Genre Genre { get; set; }

    [GraphQLIgnore]
    public int DirectorId { get; set; }

    public Director Director([Service] DirectorRepository directorRepo)
    {
        return directorRepo.GetById(DirectorId);
    }
}
