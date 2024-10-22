using GraphqlServer.Repositories;
using GraphqlServer.Types;

namespace GraphqlServer.Entities;

public interface IWatchable
{
    public int Id { get; set; }

    public string Title { get; set; }

    public Genre Genre { get; set; }
}
