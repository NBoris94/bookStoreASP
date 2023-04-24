using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.AuthorRepo;
using Repository.BookRepo;
using Repository.GenreRepo;
using Service.AuthorSer;
using Service.BookSer;
using Service.GenreSer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var users = new List<User>
{
    new User("nboris@mail.ru", "12345"),
    new User("test@mail.ru", "55555")
};

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IGenreRepository), typeof(GenreRepository));
builder.Services.AddScoped(typeof(IAuthorRepository), typeof(AuthorRepository));
builder.Services.AddScoped(typeof(IBookRepository), typeof(BookRepository));

builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookService, BookService>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience =  true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/login", (User loginData) =>
{
    var user = users.FirstOrDefault(u => u.Email == loginData.Email && u.Password == loginData.Password);

    if (user == null)
    {
        return Results.Unauthorized();
    }

    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };

    var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    var response = new
    {
        access_token = encodedJwt,
        username = user.Email
    };

    return Results.Json(response);
});

app.Map("/data", [Authorize] (HttpContext context) => $"ַהנאסüעו");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


public class AuthOptions
{
    public const string ISSUER = "AuthServer";
    public const string AUDIENCE = "AuthClient";
    const string KEY = "mysupersecret_key_1Q2w3e4R_";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}

record class User(string Email, string Password);