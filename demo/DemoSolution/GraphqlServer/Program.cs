using GraphqlServer;
using GraphqlServer.Repositories;
using HotChocolate;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

builder.Services.AddTransient<MovieRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
