using GraphqlServer;
using GraphqlServer.Entities;
using GraphqlServer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("blazorfrontend", policy => policy.WithOrigins("https://localhost:7163").AllowCredentials().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
{
    options.TokenValidationParameters.ValidateIssuer = false;
});
builder.Services.AddAuthorization();

builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(options =>
    {
        options.IncludeExceptionDetails = builder.Environment.IsDevelopment();
    })
    .AddAuthorization()
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();
