using GraphqlServer.Entities;
using GraphqlServer.Repositories;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Snapshooter.MSTest;


namespace GraphqlServer.Tests
{
    [TestClass]
    [UsesVerify]
    public partial class UnitTest1
    {
        [TestMethod]
        public async Task SchemaDoesNotChange()
        {
            var schema = await new ServiceCollection()
                .AddTransient<MovieRepository>()
                .AddTransient<DirectorRepository>()
                .AddGraphQL()
                .AddQueryType<Query>()
                .BuildSchemaAsync();

            schema.ToString().MatchSnapshot();
        }

        [TestMethod]
        public async Task SchemaDoesNotChangeWithVerify()
        {
            var schema = await new ServiceCollection()
                .AddTransient<MovieRepository>()
                .AddTransient<DirectorRepository>()
                .AddGraphQL()
                .AddQueryType<Query>()
                .BuildSchemaAsync();

            await Verify(schema.ToString());
        }

        [TestMethod]
        public async Task BestMovieTest()
        {
            var schema = new ServiceCollection()
                .AddTransient<MovieRepository>()
                .AddTransient<DirectorRepository>()
                .AddGraphQL()
                .AddQueryType<Query>();

            var result = await schema.ExecuteRequestAsync("{ bestMovie { title } }");

            var opResult = result as OperationResult;
            await Verify(result.ToJson(), "json");
            Assert.AreEqual(ExecutionResultKind.SingleResult, opResult.Kind);
        }

        [TestMethod]
        public async Task GetMovieByIdWithMockingTest()
        {
            var mockMovieRepository = Substitute.For<IMovieRepository>();
            mockMovieRepository.GetById(Arg.Any<int>()).Returns(new Movie
            {
                Title = "test title"
            });

            var schema = new ServiceCollection()
                .AddTransient<MovieRepository>()
                .AddTransient<DirectorRepository>()
                .AddTransient<IMovieRepository>(_ => mockMovieRepository)
                .AddGraphQL()
                .AddQueryType<Query>();

            var result = await schema.ExecuteRequestAsync("{ movieById(id: 18) { title } }");

            var opResult = result as OperationResult;
            await Verify(result.ToJson(), "json");
            Assert.AreEqual(ExecutionResultKind.SingleResult, opResult.Kind);
        }
    }
}