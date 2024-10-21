﻿using GraphqlServer.Entities;

namespace GraphqlServer.Repositories;

public class DirectorRepository
{
    private static List<Director> s_directors = new()
    {
        new()
        {
            Id = 4,
            Name = "James Cameron",
            DateOfBirth = new DateOnly(1954, 8, 16)
        },
        new()
        {
            Id = 8,
            Name = "John Stevenson",
            DateOfBirth = new DateOnly(1958, 4, 1)
        },
        new()
        {
            Id = 15,
            Name = "Christophen Nolan",
            DateOfBirth = new DateOnly(1970, 7, 13)
        },
        new()
        {
            Id = 16,
            Name = "Greta Gerwich",
            DateOfBirth = new DateOnly(1983, 8, 4)
        }
    };

    public Director? GetById(int id)
    {
        return s_directors.Find(x => x.Id == id);
    }
}
