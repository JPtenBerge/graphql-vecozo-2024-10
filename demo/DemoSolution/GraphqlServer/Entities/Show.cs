using GraphqlServer.Types;

namespace GraphqlServer.Entities;

public class Show : IWatchable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public int NrOfEpisodes { get; set; }
}
