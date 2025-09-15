using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplication1;
using WebApplication1.Contracts.ContractsAuthors;
using WebApplication1.Contracts.ContractsBook;
using WebApplication1.Repositories;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDb(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthorRepository, AuthorsRepositories>();
builder.Services.AddScoped<IAuthorsService, AuthorService>();

builder.Services.AddScoped<IBooksRepository, BooksRepositori>();
builder.Services.AddScoped<IBooksService, BooksService>();
var app = builder.Build();
  
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
