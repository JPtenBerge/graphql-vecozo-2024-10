using GraphqlServer.Entities;
using GraphqlServer.Types;
using System.Numerics;

namespace GraphqlServer.Repositories;

public class ShowRepository
{
    private static List<Show> s_shows = new()
    {
        new()
        {
            Id = 1,
            Title = "The big Bang Theory",
            Genre = Genre.Comedy,
            NrOfEpisodes = 279
        },
        new()
        {
            Id = 4,
            Title = "Sex and the City",
            Genre = Genre.Disaster,
            NrOfEpisodes = 279
        },
        new()
        {
            Id = 13,
            Title = "Young Sheldon",
            Genre = Genre.Comedy,
            NrOfEpisodes = 110
        },
        new()
        {
            Id = 433,
            Title = "Pokemon",
            Genre = Genre.Disaster,
            NrOfEpisodes = 9822
        }
    };

    public IEnumerable<Show> GetAll()
    {
        return s_shows;
    }
}
