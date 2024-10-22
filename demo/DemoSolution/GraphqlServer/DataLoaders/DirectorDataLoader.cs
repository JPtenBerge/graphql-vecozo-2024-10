using GraphqlServer.Entities;
using GraphqlServer.Repositories;
using System;

namespace GraphqlServer.DataLoaders;

public class DirectorDataLoader : BatchDataLoader<int, Director>
{
    private readonly DirectorRepository _repository;

    public DirectorDataLoader(
        DirectorRepository repository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _repository = repository;
    }

    protected override async Task<IReadOnlyDictionary<int, Director>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        // instead of fetching one person, we fetch multiple persons
        var persons = await _repository.GetByIds(keys);
        return persons.ToDictionary(x => x.Id);
    }
}
