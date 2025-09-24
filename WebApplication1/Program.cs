using Microsoft.AspNetCore.CookiePolicy;
using WebApplication1;
using WebApplication1.Auth;
using WebApplication1.Contracts.ContractsAppUser;
using WebApplication1.Contracts.ContractsAuthors;
using WebApplication1.Contracts.ContractsBasket;
using WebApplication1.Contracts.ContractsBook;
using WebApplication1.Contracts.ContractsCart;
using WebApplication1.Contracts.ContractsGenres;
using WebApplication1.Extensionss;
using WebApplication1.Provider;
using WebApplication1.Repositories;
using WebApplication1.Service;
using WebApplication1.Service.Hasher;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;



// База данных и AutoMapper
builder.Services.AddDb(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddControllers();

// Конфигурация JWT 
builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Аутентификация
builder.Services.AddApiAuthentication(configuration);

// Регистрация репозиториев и сервисов
builder.Services.AddScoped<IAuthorRepository, AuthorsRepositories>();
builder.Services.AddScoped<IAuthorsService, AuthorService>();

builder.Services.AddScoped<IGenresRepository, GenresRepositori>();
builder.Services.AddScoped<IGenresService, GenresService>();

builder.Services.AddScoped<IBooksRepository, BooksRepositori>();
builder.Services.AddScoped<IBooksService, BooksService>();

builder.Services.AddScoped<ICartRepository, CartItemsRepository>();
builder.Services.AddScoped<ICartService, CartItemsService>();

// Сервисы аутентификации
builder.Services.AddScoped<IHasherPassword, PasswordHasher>();
builder.Services.AddScoped<IUserRepository, AppUserRepository>();
builder.Services.AddScoped<IUserService, AppUserService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();