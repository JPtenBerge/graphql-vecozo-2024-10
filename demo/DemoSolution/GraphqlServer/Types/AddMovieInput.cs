namespace GraphqlServer.Types;

public class AddMovieInput
{
    public string Title { get; set; }

    public int ReleaseYear { get; set; }

    public int DirectorId { get; set; }
}
