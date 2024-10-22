using GraphqlServer;
using GraphqlServer.Entities;
using GraphqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("blazorfrontend", policy => policy.WithOrigins("https://localhost:7163").AllowCredentials().AllowAnyMethod().AllowAnyHeader());
});

builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(options =>
    {
        options.IncludeExceptionDetails = builder.Environment.IsDevelopment();
    })
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<IWatchable>()
    .AddType<MovieError>()
    .AddType<Show>()
    .AddType<Movie>();

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<DirectorRepository>();
builder.Services.AddTransient<ShowRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("blazorfrontend");

app.MapGraphQL();

app.Run();
