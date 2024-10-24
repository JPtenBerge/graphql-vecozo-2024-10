﻿using GraphqlServer.Entities;
using GraphqlServer.Types;
using System.Numerics;

namespace GraphqlServer.Repositories;

public class MovieRepository : IMovieRepository
{
    private static List<Movie> s_movies = new()
    {
        new()
        {
            Id = 1,
            Title = "Titanic",
            ReleaseYear = 1997,
            DirectorId = 4,
            Genre = Genre.Disaster
        },
        new()
        {
            Id = 9,
            Title = "Kung-fu Panda 4: This time it's personal",
            ReleaseYear = 2025,
            DirectorId = 8,
            Genre = Genre.Comedy
        },
        new()
        {
            Id = 6,
            Title = "Oppenheimer",
            ReleaseYear = 2023,
            DirectorId = 15,
            Genre = Genre.Disaster
        },
        new()
        {
            Id = 18,
            Title = "Matrix",
            ReleaseYear = 2023,
            DirectorId = 16,
            Genre = Genre.Thriller
        },
        new()
        {
            Id = 3845,
            Title = "Shawshank Redemption",
            ReleaseYear = 2023,
            DirectorId = 4,
            Genre = Genre.Romcom
        },
        new()
        {
            Id = 87,
            Title = "Godfather",
            ReleaseYear = 2023,
            DirectorId = 4,
            Genre = Genre.Thriller
        },
        new()
        {
            Id = 110,
            Title = "Barbie",
            ReleaseYear = 2023,
            DirectorId = 4,
            Genre = Genre.Horror
        },
    };

    public async Task<IEnumerable<Movie>> GetAll()
    {
        return s_movies;
    }

    public async Task<Movie?> GetById(int id)
    {
        return s_movies.SingleOrDefault(x => x.Id == id);
    }

    public Movie Add(string title, int releaseYear, int directorId)
    {
        var newMovie = new Movie() { DirectorId = directorId, Title = title, ReleaseYear = releaseYear };
        newMovie.Id = s_movies.Max(x => x.Id) + 1;
        s_movies.Add(newMovie);
        return newMovie;
    }

    public IEnumerable<Movie> GetByGenre(Genre genre)
    {
        return s_movies.Where(x => x.Genre == genre);
    }
}
