using GraphqlServer;
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
    .AddMutationType<Mutation>();

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<DirectorRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("blazorfrontend");

app.MapGraphQL();

app.Run();
