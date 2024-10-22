using GraphqlServer.DataLoaders;
using GraphqlServer.Repositories;
using GraphqlServer.Types;

namespace GraphqlServer.Entities;

public class Movie : IWatchable, IOffering
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int ReleaseYear { get; set; }

    public Genre Genre { get; set; }

    [GraphQLIgnore]
    public int DirectorId { get; set; }

    public async Task<Director> Director(DirectorDataLoader directorDataLoader)
    {
        Console.WriteLine("[movie] director ophalen voor id " + DirectorId);
        return await directorDataLoader.LoadRequiredAsync(DirectorId);
    }
}
