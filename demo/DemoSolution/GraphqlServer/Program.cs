using GraphqlServer;
using GraphqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(options =>
    {
        options.IncludeExceptionDetails = builder.Environment.IsDevelopment();
    })
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddTransient<MovieRepository>();
builder.Services.AddTransient<DirectorRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
